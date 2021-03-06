//
//  ViewController.swift
//  PracticeAPI
//
//  Created by Dalton on 6/22/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class PeopleViewController: UITableViewController {
    
    // data array used for tableView -- see cellForRowAt function
    var people = [String]()
    
    override func viewDidLoad() {
        
        super.viewDidLoad()
        
        // prepare request information and session
        let url = NSURL(string: "http://swapi.co/api/people/")
        let session = URLSession.shared
        
        // retrieve data from url and handle with 'completionHandler' function enclosure
        let task = session.dataTask(with: url! as URL, completionHandler: {
            // swift anonymous function definition
            data, response, error in
            do {
                // is there a result? Continue if we can cast response to dictionary type
                if let jsonResult = try JSONSerialization.jsonObject(with: data!, options: JSONSerialization.ReadingOptions.mutableContainers) as? NSDictionary {
                    
                    // cast results key to array for iteration
                    if let results = jsonResult["results"] as? NSArray {
                        for person in results {
                            // cast to dictionary for data extraction
                            let personDict = person as! NSDictionary
                            self.people.append(personDict["name"]! as! String)
                        }
                    }
                }
                // async -- if we loaded the data outside of the do-catch statement
                // it would attempt to load before we had populated the 'people' array
                self.tableView.reloadData()
            } catch {
                print(error)
            }
        })
        // task.resume() will begin a task and wait for the response to handle
        // with completionHandler. Code we put below here will likely happen before the response
        task.resume()
        print("I happen before the response!")
    }
    
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    // MARK: - Table view data source: people
    
    override func numberOfSections(in tableView: UITableView) -> Int {
        // #warning Incomplete implementation, return the number of sections
        return 1
    }
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        // #warning Incomplete implementation, return the number of rows
        return people.count
    }
    
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "personCell", for: indexPath)
        cell.textLabel?.text = people[indexPath.row]
        return cell
    }
    
}
