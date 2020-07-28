import java.sql.*;
import org.dom4j.io.SAXReader;
import org.dom4j.*;
import java.io.File;
import java.util.*;



public class driverJDBC {

    private static final String CREATE_TABLE_SQL="CREATE TABLE db.student ("
            + "ID INT NOT NULL PRIMARY KEY,"
            + "NAME VARCHAR(50),"
            + "SURNAME VARCHAR(50),"
            + "GENDER VARCHAR(45) NOT NULL,"
            + "MARKS FLOAT)";

    public static void addRow(Connection con,int Id, String FirstName, String MiddleName, String LastName,String Gender, float Marks)
    {
        try {

            PreparedStatement st = con.prepareStatement("Insert into db.student values (?,?,?,?,?)");
            st.setInt(1, Id);
            st.setString(2, FirstName+" "+MiddleName);
            st.setString(3, LastName);
            st.setString(4, Gender);
            st.setFloat(5, Marks);
            if(st.executeUpdate()>0)
                System.out.println("Record Inserted in Student\n");
            else
                System.out.println("Insertion Unsuccessful");

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
    public static void main(String[] args) {
        String jdbcUrl = "jdbc:mysql://localhost/?user=root";
        String username = "root";
        Connection con = null;
        Statement st = null;

        String FirstName=null;
        String MiddleName=null;
        String LastName=null;
        String Gender=null;
        int RollNo=0;
        float Marks=0;
        try {

            con = DriverManager.getConnection(jdbcUrl);
            st = con.createStatement();

            st.executeUpdate(CREATE_TABLE_SQL);
            st.executeUpdate("use db;");

            System.out.println("Table created");

            File xmlfile = new File("XML/input.txt");
            SAXReader saxReader = new SAXReader();
            Document document = saxReader.read(xmlfile);
            List<Node> nodes = document.selectNodes("/class/student");

            for (Node node : nodes) {
                RollNo = Integer.parseInt(node.valueOf("@rollno"));
                FirstName = node.selectSingleNode("name/firstname").getText();
                MiddleName = node.selectSingleNode("name/middlename").getText();
                LastName = node.selectSingleNode("name/lastname").getText();
                Gender = node.selectSingleNode("gender").getText();
                Marks = Float.parseFloat(node.selectSingleNode("marks").getText());
            }
            addRow(con,RollNo,FirstName,MiddleName,LastName,Gender,Marks);
            System.out.println("Table values updated");


        } catch (SQLException | DocumentException e) {
            e.printStackTrace();
        }finally {
            try {
                // Close connection
                if (st != null) {
                    st.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

    }
}