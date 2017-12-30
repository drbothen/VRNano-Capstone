var smooth = 2.0;
var DoorOpenAngle = -90.0;
private var open : boolean;
private var enter : boolean;

private var defaultRot : Quaternion;
private var openRot : Quaternion;
 
function Start(){
    defaultRot = transform.rotation;
    openRot = defaultRot * Quaternion.Euler(0, DoorOpenAngle, 0);
}
 
//Main function
function Update (){
    if(open){
        //Open door
        transform.rotation = Quaternion.Slerp(transform.rotation, openRot, Time.deltaTime * smooth);
    }else{
        //Close door
        transform.rotation = Quaternion.Slerp(transform.rotation, defaultRot, Time.deltaTime * smooth);
    }
 
    if(Input.GetKeyDown("f") && enter){
    	
        open = !open;
        GetComponent.<AudioSource>().Play();
    }
}
 
function OnGUI(){
    if(enter){
        GUI.Label(new Rect(Screen.width/2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
    }
}
 
 
//Activate the Main function when player is near the door
function OnTriggerEnter (other : Collider){
    if (other.gameObject.tag == "Player") {
        enter = true;
    }
}
 
//Deactivate the Main function when player is go away from door
function OnTriggerExit (other : Collider){
    if (other.gameObject.tag == "Player") {
        enter = false;
    }
}