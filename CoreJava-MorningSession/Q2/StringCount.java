import java.util.HashMap;
import java.util.Map;
import java.util.*;

public class StringCount

{
    public static void countbyChars(ArrayList<String> para)
    {

        Map<String, Integer> count_map = new HashMap<String, Integer>();

        //Iterates over the paragraph and increments by the number of characters
        for (String s : para) {
            Integer c = count_map.get(s);
            count_map.put(s, (c == null) ? 1 : c + 1);
        }


        for (Map.Entry<String,Integer> entry : count_map.entrySet())
            System.out.println("Count of " + entry.getKey() +
                    " is " + entry.getValue());
    }

    public static void main(String[] args) {

        ArrayList<String> InputPara = new ArrayList<String>();
        //The input paragraph is hardcoded for demonstration purposes
        InputPara.add("h");
        InputPara.add("n");
        InputPara.add("h");
        InputPara.add("y");
        InputPara.add("b");
        InputPara.add("a");
        InputPara.add("c");
        InputPara.add("h");
        InputPara.add("c");
        InputPara.add("b");
        InputPara.add("a");
        System.out.print("The input list of string is :"+InputPara);
        countbyChars(InputPara);
    }
}