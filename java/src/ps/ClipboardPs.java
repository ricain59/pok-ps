/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package ps;

import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.ClipboardOwner;
import java.awt.datatransfer.Transferable;
import java.awt.datatransfer.StringSelection;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.awt.Toolkit;
import java.io.*;
import java.util.ArrayList;
import java.util.Calendar;


public final class ClipboardPs implements ClipboardOwner {

    AppendToFile file;
    String oldcopyhand = "";
    String newcopyhand = "";
    ArrayList<String> handarray = new ArrayList<String>();
    
  public void ClipboardPs(){
    ClipboardPs textTransfer = new ClipboardPs();

    //display what is currently on the clipboard
    //System.out.println("Clipboard contains:" + textTransfer.getClipboardContents());
    
    newcopyhand = textTransfer.getClipboardContents().toString();
    
    if(!newcopyhand.equals(oldcopyhand))
    {
        if(newcopyhand.startsWith("PokerStars Hand #"))
        {
            String can = "cancelled";
            if(!newcopyhand.toLowerCase().contains(can.toLowerCase()))
            {
                if(!handarray.contains(newcopyhand))
                {
                    handarray.add(newcopyhand);
                    String date = getDate();
                    file = new AppendToFile();
                    file.AppendToFile(newcopyhand, date);
                    oldcopyhand = newcopyhand;
                    
                }
            }           
        }
    }
    //change the contents and then re-display
    //textTransfer.setClipboardContents("blah, blah, blah");
    //System.out.println("Clipboard contains:" + textTransfer.getClipboardContents());
  }

   /**
   * Empty implementation of the ClipboardOwner interface.
   */
   @Override public void lostOwnership(Clipboard aClipboard, Transferable aContents){
     //do nothing
   }

  /**
  * Place a String on the clipboard, and make this class the
  * owner of the Clipboard's contents.
  */
  public void setClipboardContents(String aString){
    StringSelection stringSelection = new StringSelection(aString);
    Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
    clipboard.setContents(stringSelection, this);
  }

  /**
  * Get the String residing on the clipboard.
  *
  * @return any text found on the Clipboard; if none found, return an
  * empty String.
  */
  public String getClipboardContents() {
    String result = "";
    Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
    //odd: the Object param of getContents is not currently used
    Transferable contents = clipboard.getContents(null);
    boolean hasTransferableText =
      (contents != null) &&
      contents.isDataFlavorSupported(DataFlavor.stringFlavor)
    ;
    if (hasTransferableText) {
      try {
        result = (String)contents.getTransferData(DataFlavor.stringFlavor);
      }
      catch (UnsupportedFlavorException | IOException ex){
        System.out.println(ex);
        ex.printStackTrace();
      }
    }
    return result;
  }
  
  public String getDate()
  {
        Calendar now = Calendar.getInstance();
        int year = now.get(Calendar.YEAR);
        int month = now.get(Calendar.MONTH); // Note: zero based!
        int day = now.get(Calendar.DAY_OF_MONTH);
        int hour = now.get(Calendar.HOUR_OF_DAY);
        return year+"_"+month+"_"+day+"_"+hour;
  }
  
  public void getTable(String handok)
  {
      String[] table = handok.split("'");            
  }
}