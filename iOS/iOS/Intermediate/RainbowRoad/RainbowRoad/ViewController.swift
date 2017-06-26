//
//  ViewController.swift
//  RainbowRoad
//
//  Created by Dalton on 5/15/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var tableView: UITableView!
    var colors: [UIColor] = [
        .red,
        .orange,
        .yellow,
        .green,
        .blue,
        .purple
    ]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        tableView.dataSource = self

//        self.tableView.backgroundColor = UIColor.clear

    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

}

extension ViewController : UITableViewDataSource {
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return colors.count
    }
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "ColorCell", for: indexPath)
        cell.textLabel?.text = ""
        cell.backgroundColor = colors[indexPath.row]
        return cell
    }
    
//    func tableView(_ tableView: UITableView, willDisplay cell: UITableViewCell, forRowAt indexPath: IndexPath) -> UITableViewCell {
//        let cell = tableView.dequeueReusableCell(withIdentifier: "ColorCell", for: indexPath)
//        cell.backgroundColor = colors[indexPath.row]
//        cell.backgroundColor = UIColor.red
//        return cell
//    }
}
