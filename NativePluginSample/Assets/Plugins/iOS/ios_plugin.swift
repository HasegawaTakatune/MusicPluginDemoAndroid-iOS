import Foundation

@objc public class Sample:NSObject{
    private static var show:String = "";
    @objc public static func hello(){
        //print("Hello Swift")
    }
    
    @objc public static func setHello(str:String){
        show.append(str);
    }
    
    @objc public static func getHello() -> String{
        show.append("\nHello Swift");
        return show;
    }
}
