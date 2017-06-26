//
//  ViewController.swift
//  ToDoList
//
//  Created by Dalton on 5/19/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit
import CoreData

class ToDoListViewController: UITableViewController {
    
    var items = [ToDoListItem]()

    let managedObjectContext = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
    
    
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return items.count
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "ListItemCell", for: indexPath) as! ToDoItemTableViewCell
        let todoitem = items[indexPath.row]
        cell.titleLabel?.text = todoitem.title
        cell.descriptionLabel?.text = todoitem.desc
        cell.dateLabel?.text = todoitem.date
        return cell
    }
    
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
//        print("Section: \(indexPath.section) and Row: \(indexPath.row)")
//        items.remove(at: indexPath.row)
        let cell = tableView.dequeueReusableCell(withIdentifier: "ListItemCell", for: indexPath)
        if (cell.accessoryType == UITableViewCellAccessoryType.checkmark){
            cell.accessoryType = UITableViewCellAccessoryType.none
        }
        else{
            cell.accessoryType = UITableViewCellAccessoryType.checkmark
        }
        tableView.reloadData()
        
    }
    

    
    func fetchAllItems(){
        let request = NSFetchRequest<NSFetchRequestResult>(entityName: "ToDoListItem")
        do{
            let result = try managedObjectContext.fetch(request)
            items = result as! [ToDoListItem]
        }
        catch{
            print("\(error)")
        }
    }
    
    
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        fetchAllItems()
//        tableView.reloadData()
        tableView.dataSource = self
        tableView.delegate = self
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

