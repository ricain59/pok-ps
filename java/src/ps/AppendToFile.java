/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package ps;

import java.io.File;
import java.io.FileWriter;
import java.io.BufferedWriter;
import java.io.IOException;
 
public class AppendToFile {
    
    public int ndt = 0;
    public int fdt = 0;

    public void AppendToFile(String handcopy, String date)
    {	
    	try{
            String data = handcopy;
            
            File file =new File("E:/HH"+fdt+"_"+date+".txt");
            ndt = ndt + 1;

            //if file doesnt exists, then create it
            if(!file.exists()){
                    file.createNewFile();
            }

            //true = append file
            FileWriter fileWritter = new FileWriter(file,true);
            BufferedWriter bufferWritter = new BufferedWriter(fileWritter);
            bufferWritter.write(data);
            bufferWritter.newLine();
            bufferWritter.newLine();
            bufferWritter.close();

            if(ndt == 1000)
            {
                fdt = fdt + 1;
                ndt = 0;
            }
 
    	}catch(IOException e){
    		e.printStackTrace();
    	}
    }
}
