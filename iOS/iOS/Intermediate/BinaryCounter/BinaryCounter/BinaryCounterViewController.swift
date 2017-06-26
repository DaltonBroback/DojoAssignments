//
//  ViewController.swift
//  BinaryCounter
//
//  Created by Dalton on 5/18/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class BinaryCounterViewController: UITableViewController {
  
    var numbers = [1, 10, 100]
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return 16
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "BinaryCounter") as! BinaryCounter
        cell.numberLabel.text = String(1000)
        return cell
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

