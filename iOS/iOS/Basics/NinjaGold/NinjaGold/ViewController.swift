//
//  ViewController.swift
//  NinjaGold
//
//  Created by Dalton on 5/10/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    @IBOutlet weak var scoreLabel: UILabel!
    @IBOutlet weak var farmLabel: UILabel!
    @IBOutlet weak var caveLabel: UILabel!
    @IBOutlet weak var houseLabel: UILabel!
    @IBOutlet weak var casinoLabel: UILabel!
    var score = 0
    var scoretoadd = 0
    var text = ""

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    @IBAction func farmPressed(_ sender: UIButton) {
        farmLabel.text = ""
        caveLabel.text = ""
        houseLabel.text = ""
        casinoLabel.text = ""
        scoretoadd = Int(arc4random_uniform(11))+10
        text = "You earned \(scoretoadd)"
        farmLabel.text = text
        score += scoretoadd
        updateUI()
    }
    @IBAction func cavePressed(_ sender: UIButton) {
        farmLabel.text = ""
        caveLabel.text = ""
        houseLabel.text = ""
        casinoLabel.text = ""
        scoretoadd = Int(arc4random_uniform(6))+5
        text = "You earned \(scoretoadd)"
        caveLabel.text = text
        score += scoretoadd
        updateUI()
    }

    @IBAction func housePressed(_ sender: UIButton) {
        farmLabel.text = ""
        caveLabel.text = ""
        houseLabel.text = ""
        casinoLabel.text = ""
        scoretoadd = Int(arc4random_uniform(4))+2
        text = "You earned \(scoretoadd)"
        houseLabel.text = text
        score += scoretoadd
        updateUI()
    }
    @IBAction func casinoPressed(_ sender: UIButton) {
        farmLabel.text = ""
        caveLabel.text = ""
        houseLabel.text = ""
        casinoLabel.text = ""
        scoretoadd = Int(arc4random_uniform(101))-50
        if (scoretoadd > 0){
            score += scoretoadd
            text = "You earned \(scoretoadd)"
        }
        else if (scoretoadd < 0){
            score += scoretoadd
            scoretoadd *= -1
            text = "You lost \(scoretoadd)"
        }
        casinoLabel.text = text
        updateUI()
    }

    
    @IBAction func resetPressed(_ sender: UIButton) {
        score = 0
        farmLabel.text = ""
        caveLabel.text = ""
        houseLabel.text = ""
        casinoLabel.text = ""
        updateUI()
    }
    
    func updateUI(){
        scoreLabel.text = String(score)
    }

}

