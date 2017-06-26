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
    
    // TODO: Figure out event handler for interface being loaded
    
    func toggleState(_ player1: Bool){
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
    
    @IBOutlet weak var resetButton: UIButton!
    var gameOver: Bool = false
    
    var gameBoard = [
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0]
    ]
    override func viewDidLoad() {
        super.viewDidLoad()
        // logic for turn lavel
        turnLabel.text = "Blue's turn"
        resetButton.isHidden = true
    }
    
    @IBAction func buttonPressed(_ sender: UIButton) {
        if gameOver { return }
        let selectedButton = sender as? GameButton
        selectedButton?.toggleState(player1)
        var player1Int: Int
        if player1{
            player1Int = 1
        }
        else {
            player1Int = 2
        }
        var playerTurnColor:String
        if player1Int == 2{
            playerTurnColor = "Blue"
        }
        else{
            playerTurnColor = "Red"
        }
        turnLabel.text = "\(playerTurnColor)'s turn"
        markBoard(tag: (selectedButton?.tag)!, player: player1Int)
        
        //        markBoard(tag: (selectedBUtton?.tag)!,player: player1Int)
        //        winCondition()
        //
        self.player1 = !player1
    }

    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func markBoard(tag: Int, player: Int){
        switch tag {
        case 1:
            gameBoard[0][0] = player
        case 2:
            gameBoard[0][1] = player
        case 3:
            gameBoard[0][2] = player
        case 4:
            gameBoard[1][0] = player
        case 5:
            gameBoard[1][1] = player
        case 6:
            gameBoard[1][2] = player
        case 7:
            gameBoard[2][0] = player
        case 8:
            gameBoard[2][1] = player
        case 9:
            gameBoard[2][2] = player
        default:
            print("oh no!")
        }
    }
}

