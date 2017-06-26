//
//  ViewController.swift
//  NSEW
//
//  Created by Dalton on 5/16/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ViewController: UIViewController{

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    @IBAction func directionButtonPressed(_ sender: UIButton ){
        performSegue(withIdentifier: "DirectionSegue", sender: sender.titleLabel!.text)
    }
    
    @IBAction func goBack(_ segue: UIStoryboardSegue){
        
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let direction = sender as! String
        let destination = segue.destination as! DirectionViewController
        destination.direction = direction
    }

}

