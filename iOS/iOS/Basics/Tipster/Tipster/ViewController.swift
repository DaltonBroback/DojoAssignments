//
//  ViewController.swift
//  Tipster
//
//  Created by Dalton on 5/13/17.
//  Copyright © 2017 Dalton Broback. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    func displayNumber(){
        numberLabel.text = num
    }
    func addnum(number: String){
        num += number
        displayNumber()
    }
    @IBAction func button9(_ sender: Any) {
        addnum(number: "9")
    }
    @IBAction func button8(_ sender: Any) {
        addnum(number: "8")
    }
    @IBAction func button7(_ sender: Any) {
        addnum(number: "7")
    }
    @IBAction func button6(_ sender: Any) {
        addnum(number: "6")
    }
    @IBAction func button5(_ sender: Any) {
        addnum(number: "5")
    }
    @IBAction func button4(_ sender: Any) {
        addnum(number: "4")
    }
    @IBAction func button3(_ sender: Any) {
        addnum(number: "3")
    }
    @IBAction func button2(_ sender: Any) {
        addnum(number: "2")
    }
    @IBAction func button1(_ sender: Any) {
        addnum(number: "1")
    }
    @IBAction func button0(_ sender: Any) {
        addnum(number: "0")
    }
    @IBAction func buttonPoint(_ sender: Any) {
        if num == ""{
            addnum(number: "0.")
        }
        else{
            addnum(number: ".")
        }
    }
    @IBAction func buttonC(_ sender: Any) {
        num = "0"
        displayNumber()
    }

    @IBOutlet weak var numberLabel: UILabel!
    
    @IBOutlet weak var lowPercent: UILabel!
    @IBOutlet weak var lowTip: UILabel!
    @IBOutlet weak var lowTotal: UILabel!
    
    @IBOutlet weak var midPercent: UILabel!
    @IBOutlet weak var midTip: UILabel!
    @IBOutlet weak var midTotal: UILabel!
    
    @IBOutlet weak var highPercent: UILabel!
    @IBOutlet weak var highTip: UILabel!
    @IBOutlet weak var highTotal: UILabel!
    
    
    var num: String = ""
    var lowTipVal: String = "10"
    var midTipVal: String = "15"
    var highTipVal: String = "20"
 
    func displayLowPercent(){
        lowPercent.text = lowTipVal + "%"
    }
    func displayMidPercent(){
        midPercent.text = midTipVal + "%"
    }
    func displayHighPercent(){
        highPercent.text = highTipVal + "%"
    }
    

    override func viewDidLoad() {
        super.viewDidLoad()
        numberLabel.text = "0"
        displayLowPercent()
        displayMidPercent()
        displayHighPercent()
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

}

