//
//  NotesListViewController.swift
//  BeltExam
//
//  Created by Dalton on 5/25/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit
import CoreData
import Foundation

class NotesListViewController: UITableViewController, UISearchBarDelegate, AddItemTableViewControllerDelegate {
    
    @IBOutlet weak var searchBar: UITableView!
    var notes = [NoteListItem]()
    var filtered = [NoteListItem]()
    let searchController = UISearchController(searchResultsController: nil)
    let managedObjectContext = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
    
    func filterContentForSearchText(searchText: String, scope: String = "All"){
        filtered = notes.filter { note in
            return note.note!.lowercased().contains(searchText.lowercased())
        }
        tableView.reloadData()
    }
    
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        if searchController.isActive && searchController.searchBar.text != ""{
            return filtered.count
        }
        return notes.count
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "NoteCell") as! ListItemTableViewCell
        let i = indexPath.row
        let listitem: NoteListItem
        if searchController.isActive && searchController.searchBar.text != "" {
            listitem = filtered[i]
        } else {
            listitem = notes[i]
        }
        let str = listitem.date!
        let start = str.index(str.startIndex, offsetBy: 0)
        let end = str.index(str.endIndex, offsetBy: -8)
        let range = start..<end
        
        let truncatedDate = str.substring(with: range)
        
        cell.titleLabel?.text = listitem.note
        cell.dateLabel?.text = truncatedDate
        return cell
    }
    
    override func tableView(_ tableView: UITableView, commit editingStyle: UITableViewCellEditingStyle, forRowAt indexPath: IndexPath){
        let i = indexPath.row
        let note: NoteListItem
        if searchController.isActive && searchController.searchBar.text != "" {
            note = filtered[i]
            managedObjectContext.delete(note)
            filtered.remove(at: i)
        } else {
            note = notes[i]
            managedObjectContext.delete(note)
            notes.remove(at: i)
        }

        do {
            try managedObjectContext.save()
        } catch {
            print("\(error)")
        }
//        searchController.isActive = false
//        searchController.searchBar.text = ""
        tableView.reloadData()
    }
    
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        performSegue(withIdentifier: "EditItemSegue", sender: indexPath)
        tableView.reloadData()
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?){
        if segue.identifier == "AddItemSegue"{
            let addItemTableViewController = segue.destination as! AddItemViewController
            
            addItemTableViewController.delegate = self
            
            let note = NSEntityDescription.insertNewObject(forEntityName: "NoteListItem", into: managedObjectContext) as! NoteListItem
            let dateFormatter = DateFormatter()
            dateFormatter.dateFormat = "MM-dd-yyyy HH:mm:ss"
            let strDate = dateFormatter.string(from: Date())
            note.date = strDate
            notes.append(note)
            
        } else if segue.identifier == "EditItemSegue" {
            let addItemTableViewController = segue.destination as! AddItemViewController
            addItemTableViewController.delegate = self
            
            let indexPath = sender as! NSIndexPath
            let i = indexPath.row
            let theNote: NoteListItem
            if searchController.isActive && searchController.searchBar.text != ""{
                theNote = filtered[i]
            } else {
                theNote = notes[i]
            }
            addItemTableViewController.textToAdd = theNote.note
            addItemTableViewController.indexPath = indexPath
            addItemTableViewController.count = notes.count-1
        }
    }

    
    func fetchAllItems(){
        let request = NSFetchRequest<NSFetchRequestResult>(entityName: "NoteListItem")
        let sortDescriptor = NSSortDescriptor(key: "date", ascending: false)
        let sortDescriptors = [sortDescriptor]
        request.sortDescriptors = sortDescriptors
        do{
            let result = try managedObjectContext.fetch(request)
            notes = result as! [NoteListItem]
        }
        catch{
            print("\(error)")
        }
    }

    func itemSaved(by controller: AddItemViewController, with text: String, at indexPath: NSIndexPath?){
        let dateFormatter = DateFormatter()
        dateFormatter.dateFormat = "MM-dd-yyyy HH:mm:ss"
        let strDate = dateFormatter.string(from: Date())
        if let ip = indexPath {
            let i = ip.row
            let note = notes[i]
            note.note = text
            note.date = strDate
            notes.append(note)
        } else {
            let i = notes.count - 1
            let note = notes[i]
            note.note = text
            note.date = strDate
        }
        do {
            try managedObjectContext.save()
        } catch {
            print("\(error)")
        }
        if managedObjectContext.hasChanges {
            do {
                try managedObjectContext.save()
            } catch {
                let nserror = error as NSError
                print("Unresolved error \(nserror), \(nserror.userInfo)")
                abort()
            }
        }
        dismiss(animated: true, completion: nil)
    }
    
//    func deleteNewest()
//    {
//        let i = notes.count-1
//        let note = notes[i]
//        managedObjectContext.delete(note)
//        notes.remove(at: i)
//        do {
//            try managedObjectContext.save()
//        } catch {
//            print("\(error)")
//        }
//        if managedObjectContext.hasChanges {
//            do {
//                try managedObjectContext.save()
//            } catch {
//                let nserror = error as NSError
//                print("Unresolved error \(nserror), \(nserror.userInfo)")
//                abort()
//            }
//        }
//    }
    
    override func viewDidAppear(_ animated: Bool) {
        fetchAllItems()
        if notes.count > 0 && notes[0].note == nil{
            
            let note = notes[0]
            managedObjectContext.delete(note)
            notes.remove(at: 0)
        }
        do {
            try managedObjectContext.save()
        } catch {
            print("\(error)")
        }
        if managedObjectContext.hasChanges {
            do {
                try managedObjectContext.save()
            } catch {
                let nserror = error as NSError
                print("Unresolved error \(nserror), \(nserror.userInfo)")
                abort()
            }
        }
        tableView.reloadData()
    }
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        fetchAllItems()
        tableView.dataSource = self
        tableView.delegate = self
        searchBar.delegate = self
        searchController.searchResultsUpdater = self
        searchController.dimsBackgroundDuringPresentation = false
        definesPresentationContext = true
        tableView.tableHeaderView = searchController.searchBar
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
}

extension NotesListViewController : UISearchResultsUpdating {
    func updateSearchResults(for searchController: UISearchController) {
        filterContentForSearchText(searchText: searchController.searchBar.text!)
    }
}

