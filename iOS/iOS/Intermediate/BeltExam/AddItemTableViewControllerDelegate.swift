//
//  AddItemTableViewControllerDelegate.swift
//  BeltExam
//
//  Created by Dalton on 5/25/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import Foundation

protocol AddItemTableViewControllerDelegate: class {
    func itemSaved(by controller: AddItemViewController, with text: String, at indexPath: NSIndexPath?)
}

