import java.io.*;
// Importing specific File Class for directory access
import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.io.File;
import java.io.IOException;
import java.nio.channels.FileChannel;

//import org.apache.commons.io.FileUtils;


public class Main {
    public static void main(String[] args) {
        System.out.println("Hello world!");
        String filepath;
        filepath="D:\\FS_TESTAFP2PDF_ESTATEMENT_MASTER\\STATEMENT";
        File currentDir = new File(filepath);
        displayDirectory(currentDir);
    }
    public static void displayDirectory(File dir)
    {

        try {
            File[] files = dir.listFiles();
            //File[] files1=dir.listFiles();
            //String drSource;
            String chkNewPath="";
            String chkOldPath="";
            // For-each loop for iteration
            for (File file : files) {

                // Checking of file inside directory
                if (file.isDirectory()) {

                    // Display directories inside directory
                    System.out.println(
                            "directory:"
                                    + file.getCanonicalPath());
                    displayDirectory(file);
                    //drSource=file.getCanonicalPath();
                    chkNewPath=file.getCanonicalPath();
                    if (chkNewPath.contains("DD11")) {
                        //System.out.println("OK");
                        Path path = Paths.get(chkOldPath);
                        chkOldPath=chkNewPath.replace("DD11","O4");
                        chkOldPath="D:\\FS_TESTAFP2PDF_ESTATEMENT_MASTER\\Destination\\";
                        chkNewPath="D:\\FS_TESTAFP2PDF_ESTATEMENT_MASTER\\Source\\";
                        System.out.println(chkOldPath);
                        if (Files.exists(path)) {
                            System.out.println("Dup");

                            //File source = new File(chkNewPath);
                            //File dest = new File(chkOldPath);
                            try {
                                FileChannel source=new FileInputStream(new File(chkNewPath)).getChannel();
                                FileChannel desti=new FileOutputStream(new File(chkOldPath)).getChannel();
                                desti.transferFrom(source, 0, source.size());
                                source.close();
                                desti.close();
                            } catch (IOException e) {
                                e.printStackTrace();
                            }
                        }
                        else
                            {
                                System.out.println("NEW");
                        }
                    }
                }

                // Simply get the path
                else {
                    System.out.println(
                            "     file:"
                                    + file.getCanonicalPath());
                }
            }
        }

        // if any exceptions occurs printStackTrace
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    static void copy(Path source, Path dest) {
        try {
            Files.copy(source, dest, StandardCopyOption.REPLACE_EXISTING);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage(), e);
        }
    }

}