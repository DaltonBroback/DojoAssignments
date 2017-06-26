//
//  AddItemViewController.swift
//  ToDoList
//
//  Created by Dalton on 5/23/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit
import CoreData

class AddItemViewController : UIViewController {
  
    @IBOutlet weak var titleInput: UITextField!
    @IBOutlet weak var descriptionInput: UITextView!
    @IBOutlet weak var dateInput: UIDatePicker!
    
    let managedObjectContext = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
    
    @IBAction func cancelButtonPressed(_ sender: UIBarButtonItem) {
        dismiss(animated: true, completion: nil)

    }
    @IBAction func addItemButtonPressed(_ sender: UIButton) {
        let title = titleInput.text
        let desc = descriptionInput.text
        
        let dateFormatter = DateFormatter()
        dateFormatter.dateFormat = "dd-MM-yyyy"
        let strDate = dateFormatter.string(from: dateInput.date)
//        self.selectedDate.text = strDate
//        
//        let thedate = dateInput
//        
    
        let item = ToDoListItem(context: managedObjectContext)
        
        item.title = title
        item.desc = desc
        item.date = strDate
        if managedObjectContext.hasChanges {
            do {
                try managedObjectContext.save()
                print("Success!")
            } catch {
                let nserror = error as NSError
                print("Unresolved error \(nserror), \(nserror.userInfo)")
                abort()
            }
        }
        dismiss(animated: true, completion: nil)
    }
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
}
