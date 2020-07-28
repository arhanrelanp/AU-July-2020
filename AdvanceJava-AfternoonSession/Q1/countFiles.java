import java.io.File;
public class countFiles {
    static int count2=0;
    public static int getCount(File file){
        File[] files = file.listFiles();
        int count1 = 0;
        for(File f:files){
            if(f.isDirectory()){
                count2 += 1;
                count1 += getCount(f);
            }
            else{
                count1 += 1;
            }

        }
        return count1;


        }
    public static void main(String args[]){
        String dirPath="C:\\Users\\Stuti\\classiccounter";
        File dir = new File(dirPath);
        if(dir.exists()&&dir.isDirectory()){
            int c;
            c=getCount(dir);
            System.out.println("Number of files: "+c+"\nNumber of subdirectories: "+count2);

        }

    }}

