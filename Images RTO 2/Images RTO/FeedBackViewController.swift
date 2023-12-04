//
//  AskLibrarianViewController.swift
//  DLibrary
//
//  Created by MAC_04_31_24 on 02/02/16.
//  Copyright © 2016 diet. All rights reserved.
//

import UIKit

import SystemConfiguration

//class BottomBorderTF: UITextField {
//    
//    var bottomBorder = UIView()
//    override func awakeFromNib() {
//        
//        //MARK: Setup Bottom-Border
//        self.translatesAutoresizingMaskIntoConstraints = false
//        bottomBorder = UIView.init(frame: CGRect(x: 0, y: 0, width: 0, height: 1))
//        bottomBorder.backgroundColor = GlobalData.hexStringToUIColor("#4CAF50")
//        bottomBorder.translatesAutoresizingMaskIntoConstraints = false
//        addSubview(bottomBorder)
//        //Mark: Setup Anchors
//        bottomBorder.bottomAnchor.constraint(equalTo: bottomAnchor).isActive = true
//        bottomBorder.leftAnchor.constraint(equalTo: leftAnchor).isActive = true
//        bottomBorder.rightAnchor.constraint(equalTo: rightAnchor).isActive = true
//        bottomBorder.heightAnchor.constraint(equalToConstant: 1).isActive = true // Set Border-Strength
//        
//    }
//}
class FeedBackViewController: UIViewController ,HttpWrapperDelegate, UITextFieldDelegate {
    
    @IBOutlet var lblMessage: UILabel!
    @IBOutlet weak var btnSend: UIButton!
    @IBOutlet weak var txtname: UITextField!
    @IBOutlet weak var txtcontact: UITextField!
    @IBOutlet weak var txtEmail: UITextField!
    @IBOutlet weak var lblCity: UILabel!
    @IBOutlet weak var lblFeedback: UILabel!
    @IBOutlet weak var lblMobile: UILabel!
    @IBOutlet weak var lblName: UILabel!
    @IBOutlet weak var txtmessage: UITextView!
    @IBOutlet weak var vwForm: UIView!
    
    
    var activityIndicator = UIActivityIndicatorView()
    var messageFrame = UIView()
    let bottomline = CALayer()
    let bottomline1 = CALayer()
    let bottomline2 = CALayer()
    var feedbackRequest = HttpWrapper()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.title = "Feedback"
        self.txtmessage.layer.borderWidth = 1.0;
        self.txtmessage.layer.borderColor  = GlobalData.hexStringToUIColor("#4CAF50").cgColor
        lblMessage.text = "\nFeedback and suggestions are most welcome. We will get back to you for all your suggestions. You can also reach out to us at aswdc@darshan.ac.in"
        //        self.setTextFieldBorder(txtname, bottomLine: bottomline)
        //        self.setTextFieldBorder(txtcontact, bottomLine: bottomline1)
        //        self.setTextFieldBorder(txtEmail, bottomLine: bottomline2)
        //txtname.becomeFirstResponder()
        txtcontact.delegate = self
        
    }
    @IBAction func backbuttonAction(_ sender: UIButton) {
        self.navigationController?.popViewController(animated: true)
    }
    
    //    func setTextFieldBorder(_ txt:UITextField, bottomLine:CALayer)
    //    {
    //        bottomLine.frame = CGRect(x: 0.0, y: txt.frame.size.height - 1, width: txt.frame.size.width, height: txt.frame.size.height)
    //        bottomLine.borderColor = GlobalData.hexStringToUIColor("#4CAF50").cgColor
    //        bottomLine.borderWidth = 290
    //        txt.layer.masksToBounds = true
    //        txt.layer.addSublayer(bottomLine)
    //    }
    
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        textField.resignFirstResponder()
        return true
    }
    
    func textField(_ textField: UITextField, shouldChangeCharactersIn range: NSRange, replacementString string: String) -> Bool {
        
        let maxLength = 10
        let currentString: NSString = textField.text! as NSString
        let newString: NSString =
            currentString.replacingCharacters(in: range, with: string) as NSString
        return newString.length <= maxLength
        
    }
    
    func dismissKeyboard() {
        
        txtname.resignFirstResponder()
        txtcontact.resignFirstResponder()
        txtEmail.resignFirstResponder()
        txtmessage.resignFirstResponder()
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    
    @IBAction func clearAction(_ sender: Any) {
        txtname.text = ""
        txtmessage.text = ""
        txtEmail.text = ""
        txtcontact.text = ""
        txtname.becomeFirstResponder()
    }
    
    
    @IBAction func sendMail(_ sender: AnyObject) {
        
        var message = "Please enter "
        
        if txtname.text?.trimmingCharacters(in: .whitespacesAndNewlines) == ""
        {
            message = message + "Name "
        }
        else if(txtmessage.text?.trimmingCharacters(in: .whitespacesAndNewlines) == "")
        {
            message = message +  "Message"
        }
        if (txtcontact.text!.trimmingCharacters(in: .whitespacesAndNewlines) != "")
        {
            if(!validatePhoneNumber(value: txtcontact.text!.trimmingCharacters(in: .whitespacesAndNewlines)))
            {
                message = message + "valid Mobile Number"
                
            }
        }
        if txtEmail.text!.trimmingCharacters(in: .whitespacesAndNewlines) != ""
        {
            if(!isValidEmail(testStr: txtEmail.text!.trimmingCharacters(in: .whitespacesAndNewlines)))
            {
                
                if(message == "Please enter ")
                {
                    message = message + "Valid Email "
                }
                else
                {
                    message = message + ", Valid Email "
                }
                
            }
        }
        
        
        if(message != "Please enter ")
        {
            
            GlobalData.showMessage(self1: self, message: message)
        }
            
        else
        {
            serviceCall()
        }
        
    }
    func serviceCall()
    {
        if(GlobalData.isInternetAvailable())
        {
            GlobalData.displayActivityIndicator(view: self.view, msg: "Loading...")
            let dic: [String: AnyObject] = [
                "AppName" : "RTO Vehicle Owner Information" as AnyObject,
                "VersionNo": "2.0" as AnyObject,
                "Platform": "IOS" as AnyObject ,
                "PersonName" : txtname.text!.trimmingCharacters(in: .whitespacesAndNewlines) as AnyObject,
                "Mobile" : txtcontact.text!.trimmingCharacters(in: .whitespacesAndNewlines) as AnyObject,
                "Email" : txtEmail.text!.trimmingCharacters(in: .whitespacesAndNewlines) as AnyObject,
                "Message" : txtmessage.text!.trimmingCharacters(in: .whitespacesAndNewlines) as AnyObject
            ]
            let tempUrl = NSString(format: "http://api.aswdc.in/Api/MST_AppVersions/PostAppFeedback/AppPostFeedback" as NSString)
            self.feedbackRequest = HttpWrapper.init()
            self.feedbackRequest.delegate = self;
            self.feedbackRequest.requestWithparamdictParamPostMethod(tempUrl as String, dicsParams: dic)
        }
        else
        {
            self.displaynoInternetconnection()
        }
    }
    func HttpWrapperfetchDataSuccess(_ wrapper: HttpWrapper, dicsResponse: NSDictionary) {
        GlobalData.hideActivityIndicator(view: self.view)
        
        print(dicsResponse)
        if(String(describing: dicsResponse.value(forKey: "IsResult")!) == "1")
        {
            let alert = UIAlertController(title: "", message:"Hi! Thank you for your valuable feedback. We will get back to you at the earliest. You can also reach out to us at aswdc@darshan.ac.in", preferredStyle: UIAlertController.Style.alert)
            alert.addAction(UIAlertAction(title: "OK", style: .default, handler: { (action: UIAlertAction!) in
                self.navigationController?.popViewController(animated: true)
            }))
            
            self.present(alert, animated: true, completion: nil)
        }
        else
        {
            GlobalData.showMessage(self1: self, message: "Error occurred please try again late")
            
        }
    }
    
    func HttpWrapperfetchDataFail(_ wrapper: HttpWrapper, error: NSError, statusCode: Int) {
        GlobalData.hideActivityIndicator(view: self.view)
        
        GlobalData.showMessage(self1: self, message: "Error occurred please try again late")
        
    }
    
    func displaynoInternetconnection()
    {
        GlobalData.showMessage(self1: self, message: "Please check your internet connection.")
    }
    func isValidEmail(testStr:String) -> Bool {
        print("validate emilId: \(testStr)")
        let emailRegEx = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}"
        let emailTest = NSPredicate(format:"SELF MATCHES %@", emailRegEx)
        let result = emailTest.evaluate(with: testStr)
        return result
    }
    
    func validatePhoneNumber(value: String) -> Bool {
        let PHONE_REGEX = "^\\d{3}\\d{3}\\d{4}$"
        let phoneTest = NSPredicate(format: "SELF MATCHES %@", PHONE_REGEX)
        let result =  phoneTest.evaluate(with: value)
        return result
    }
    
}

