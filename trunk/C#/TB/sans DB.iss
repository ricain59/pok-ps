; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Poker BRM"
#define MyAppVersion "Poker BRM v1.84"
#define MyAppPublisher "Poker BRM"
#define MyAppExeName "Poker BRM.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{72F951AB-5C78-4795-BE30-5408618EAA3C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=C:\Users\ricain\Desktop
OutputBaseFilename={#MyAppVersion}
SetupIconFile=M:\Dropbox\taff et autre\pok-ps\C#\TB\TiltStopLoss\TiltStopLoss\pbrm.ico
Compression=lzma
SolidCompression=yes
WizardImageFile=M:\Dropbox\taff et autre\pok-ps\C#\TB\TiltStopLoss\TiltStopLoss\bin\pbrm.bmp
WizardSmallImageFile=M:\Dropbox\taff et autre\pok-ps\C#\TB\TiltStopLoss\TiltStopLoss\bin\pbrm.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "greek"; MessagesFile: "compiler:Languages\Greek.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "scottishgaelic"; MessagesFile: "compiler:Languages\ScottishGaelic.isl"
Name: "serbiancyrillic"; MessagesFile: "compiler:Languages\SerbianCyrillic.isl"
Name: "serbianlatin"; MessagesFile: "compiler:Languages\SerbianLatin.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Users\ricain\Desktop\Poker BRM\Poker BRM.exe"; DestDir: "{app}"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\config\"; DestDir: "{app}\config"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\error\"; DestDir: "{app}\error"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\help\"; DestDir: "{app}\help"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\"; DestDir: "{app}\help\images"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\sounds\"; DestDir: "{app}\sounds"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\x64\"; DestDir: "{app}\x64"; Flags: ignoreversion
; Source: "C:\Users\ricain\Desktop\Poker BRM\x86\"; DestDir: "{app}\x86"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\EntityFramework.SqlServer.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\EntityFramework.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Mono.Security.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Npgsql.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Npgsql.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Npgsql.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Poker BRM.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Poker BRM.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Poker BRM.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Poker BRM.vshost.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\Poker BRM.vshost.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\policy.2.0.Npgsql.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\policy.2.0.Npgsql.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\StarRatingControl.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\System.Data.SQLite.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\System.Data.SQLite.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\header.html"; DestDir: "{app}\help"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\header_en.html"; DestDir: "{app}\help"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\header_fr.html"; DestDir: "{app}\help"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\header_pt.html"; DestDir: "{app}\help"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\newcss.css"; DestDir: "{app}\help"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\confstop.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\confstop2.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\DB.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\db_ok.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\Logo.jpg"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\player.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\ragequit.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\resumesession.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\session.jpg"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\start.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\help\images\start2.JPG"; DestDir: "{app}\help\images"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\sounds\alarm.wav"; DestDir: "{app}\sounds"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\sounds\ring.wav"; DestDir: "{app}\sounds"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\x64\SQLite.Interop.dll"; DestDir: "{app}\x64"; Flags: ignoreversion
Source: "C:\Users\ricain\Desktop\Poker BRM\x86\SQLite.Interop.dll"; DestDir: "{app}\x86"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Dirs]
Name: "{app}\config"; Flags: uninsalwaysuninstall
Name: "{app}\error"; Flags: uninsalwaysuninstall
Name: "{app}\help"; Flags: uninsalwaysuninstall
Name: "{app}\help\images"; Flags: uninsalwaysuninstall
Name: "{app}\sounds"; Flags: uninsalwaysuninstall
Name: "{app}\x64"; Flags: uninsalwaysuninstall
Name: "{app}\x86"; Flags: uninsalwaysuninstall
