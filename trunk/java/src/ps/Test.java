/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package ps;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import com.sun.jna.Native;
import com.sun.jna.Pointer;
import com.sun.jna.win32.*;
import com.sun.jna.platform.win32.*;
import com.sun.jna.platform.win32.WinDef.HWND;
import com.sun.jna.platform.win32.WinUser.WNDENUMPROC;

/**
 *
 * @author ricain
 */
public class Test {
    
    public void Test()
    {
        try {
        String line;
        Process p = Runtime.getRuntime().exec(System.getenv("windir") +"\\system32\\"+"tasklist.exe");
        BufferedReader input =
                new BufferedReader(new InputStreamReader(p.getInputStream()));
        while ((line = input.readLine()) != null) {
            System.out.println(line); //<-- Parse data here.
            }
            input.close();
        } catch (Exception err) {
            err.printStackTrace();
        }
    }
    
    public void Test2()
    {
        WinDef.HWND hWnd = User32.INSTANCE.FindWindow("Numerowia II - $0.05/$0.10 USD - No Limit Hold'em", "Numerowia II - $0.05/$0.10 USD - No Limit Hold'em");
        User32.INSTANCE.ShowWindow(hWnd, WinUser.SW_SHOWMINIMIZED);        
    }
}
