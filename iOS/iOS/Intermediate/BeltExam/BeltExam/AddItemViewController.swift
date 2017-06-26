//
//  ViewController.swift
//  BeltExam
//
//  Created by Dalton on 5/25/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit
import CoreData

var NewText: String?

class AddItemViewController: UIViewController, UITextViewDelegate {
    
    var textToAdd: String?
    var indexPath: NSIndexPath?
    var count: Int?

    
    weak var delegate: AddItemTableViewControllerDelegate?
    weak var controller: NotesListViewController?

    let managedObjectContext = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext

    @IBOutlet weak var textInput: UITextView!
    
    func textViewDidChange(_ textView: UITextView) {
        let theText = textInput.text
        delegate?.itemSaved(by: self, with: theText!, at: indexPath)
    }
    override func viewDidLoad() {
        super.viewDidLoad()
        textInput.text = textToAdd
        textInput.delegate = self
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }

}
