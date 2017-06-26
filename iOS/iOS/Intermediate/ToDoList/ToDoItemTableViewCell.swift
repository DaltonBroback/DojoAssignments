//
//  ToDoItemTableViewCell.swift
//  ToDoList
//
//  Created by Dalton on 5/24/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ToDoItemTableViewCell: UITableViewCell {
    
    @IBOutlet weak var titleLabel: UILabel!
    @IBOutlet weak var descriptionLabel: UILabel!
    @IBOutlet weak var dateLabel: UILabel!
    
    override func awakeFromNib(){
        super.awakeFromNib()
    }
}
