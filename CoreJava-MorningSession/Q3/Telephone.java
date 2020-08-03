import java.util.*;

interface telephone_interface{
    void startCall(String s);
    void terminateCall();
    void redial();
    void receiveCall(String r);
    void callLog();
}

class telephone implements telephone_interface{

    public boolean on_call;
    public  Stack<String> stack = new Stack<String>();

    telephone(){
        on_call= false;
        stack.push("no calls made yet");

    }

    @Override
    public void startCall(String s)
    {
        String str;
        if(on_call==false)
        {
            if(s.matches(" "))
            {

                Scanner sc= new Scanner(System.in);
                System.out.print("enter 10 digit number: ");
                str= sc.nextLine();
            }
            else{ str=s; }
            System.out.println("Calling: "+str+"...");
            stack.push(str);
            terminateCall();

        }
        else
        {
            System.out.println("Already on call");
        }

    }

    @Override
    public void terminateCall()
    {
        System.out.println("Press E to end the call");
        Scanner sc= new Scanner(System.in);
        String str= sc.nextLine();
        if(str.regionMatches(true,0,"E",0,1))
        {

            System.out.println("call terminated...");
            on_call = false;
        }
    }

    @Override
    public void redial()
    {
        if(!on_call)
        {
            String s = stack.peek();
            System.out.println("Redialling the last number in your list : "+s);
            startCall(s);
        }
    }

    @Override
    public void receiveCall(String r)
    {
        on_call = true;
        System.out.println(r+" is calling you");
        System.out.println("Press R to not take this call : Press Reject | Press any other button to take the call");
        Scanner sc= new Scanner(System.in);
        String str= sc.nextLine();
        if(str.matches("R"))
        {
            System.out.println("call rejected from "+r);
        }
        else
        {
            System.out.println("Talking to "+r+" .....");
            terminateCall();
        }
    }

    @Override
    public void callLog()
    {
        System.out.println("the call history is :"+stack);
    }



}
class Main{
    public static void main(String[] args) {
        telephone obj = new telephone();
        obj.startCall(" ");
        obj.redial();
        obj.receiveCall("9968805623");
        obj.callLog();
    }
}