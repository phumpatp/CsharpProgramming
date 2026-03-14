package test_copyDi;

import java.io.File;
import java.io.IOException;

import org.apache.commons.io.FileUtils;

public class Process {

	public static void main(String[] args) {
		File source = new File("H:\\work-temp\\file");
		File dest = new File("H:\\work-temp\\file2");
		try {
		    FileUtils.copyDirectory(source, dest);
		} catch (IOException e) {
		    e.printStackTrace();
		}

	}

}
