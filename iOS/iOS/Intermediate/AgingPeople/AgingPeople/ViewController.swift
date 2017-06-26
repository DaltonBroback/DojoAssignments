//
//  ViewController.swift
//  AgingPeople
//
//  Created by Dalton on 5/15/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    @IBOutlet weak var tableView: UITableView!
    
    var names = [
    "Dalton",
    "Lucia",
    "Bruce",
    "Selena",
    "Dick",
    "Kori",
    "Barbara",
    "Tim",
    "Tamara",
    "Cassandra",
    "Ed",
    "Damian",
    "Angelina",
    "Talia"
    ]

    override func viewDidLoad() {
        super.viewDidLoad()
        tableView.dataSource = self

        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    
}

extension ViewController : UITableViewDataSource {
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return names.count
    }
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let age = arc4random_uniform(90)+5
        let cell = tableView.dequeueReusableCell(withIdentifier: "MyCell", for: indexPath)
        cell.textLabel?.text = names[indexPath.row]
        cell.detailTextLabel?.text = "\(age) years old"
        return cell
    }
}
