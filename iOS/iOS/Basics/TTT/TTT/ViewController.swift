//
//  ViewController.swift
//  TTT
//
//  Created by Dalton on 5/10/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class GameButton: UIButton {
    var player: String = "unclaimed"
    
    func toggelState(_ player1: Bool){
        if player1 {
            self.player = "Blue"
            self.backgroundColor = UIColor.blue
        } else {
            self.player = "Red"
            self.backgroundColor = UIColor.red

        }
    }
    
}

class ViewController: UIViewController {
    
    var player1: Bool = true
    
    @IBOutlet weak var turnLabel: UILabel!
    
    var gameBoard = [
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0]
    ]

    @IBAction func buttonPressed(_ sender: UIButton) {
        let selectedButton = sender as? GameButton
        selectedButton.toggleState(player1)
        self.player1 = !player1
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

