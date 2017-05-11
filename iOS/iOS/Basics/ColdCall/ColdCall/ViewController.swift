//
//  ViewController.swift
//  ColdCall
//
//  Created by Dalton on 5/10/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    @IBOutlet weak var nameLabel: UILabel!
    @IBOutlet weak var numLabel: UILabel!
    var currentName = 0
    let nameBank = ["Dalton","Lucia","Ed","Tim","Barbara","Cassandra","Bruce","Selena"]
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    @IBAction func answerButtonPressed(_ sender: UIButton) {
        let namePos = Int(arc4random_uniform(UInt32(nameBank.count)))
        nameLabel.text = nameBank[namePos]
        let num = arc4random_uniform(5)+1
        if (num < 3) {
            numLabel.textColor = UIColor.red
        }
        else if (num < 5){
            numLabel.textColor = UIColor.orange
        }
        else{
            numLabel.textColor = UIColor.green
        }
        numLabel.text = String(num)
    }

}

 
