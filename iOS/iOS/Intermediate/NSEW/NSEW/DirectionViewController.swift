//
//  DirectionViewController.swift
//  NSEW
//
//  Created by Dalton on 5/16/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class DirectionViewController: UIViewController {
    
    var direction = "Error"
    @IBOutlet weak var directionLabel: UIButton!

    
    override func viewDidLoad() {
        super.viewDidLoad()
        directionLabel.setTitle(direction, for: .normal)
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    
}
