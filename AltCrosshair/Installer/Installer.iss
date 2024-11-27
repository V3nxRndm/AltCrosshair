; Inno Setup Skript für AltCrosshair Projekt

[Setup]
AppName=AltCrosshair
AppVersion=1.0.0
AppPublisher=LW
AppPublisherURL=https://github.com/V3nxRndm
DefaultDirName={autopf}\AltCrosshair
DefaultGroupName=AltCrosshair
OutputDir=.\Output
OutputBaseFilename=AltCrosshairInstaller
Compression=lzma
SolidCompression=yes
DisableProgramGroupPage=yes

[Files]

Source: "bin\Release\net5.0-windows\publish\AltCrosshair.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "bin\Release\net5.0-windows\publish\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "bin\Release\net5.0-windows\publish\*.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs

Source: "app.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "Package.appxmanifest"; DestDir: "{app}"; Flags: ignoreversion

Source: "Assets\*"; DestDir: "{app}\Assets"; Flags: ignoreversion recursesubdirs

[Icons]
Name: "{autoprograms}\AltCrosshair"; Filename: "{app}\AltCrosshair.exe"
Name: "{desktop}\AltCrosshair"; Filename: "{app}\AltCrosshair.exe"

[Registry]
Name: "HKEY_CURRENT_USER\Software\AltCrosshair"; ValueType: string; ValueData: "{app}\AltCrosshair.exe"

[Run]
Filename: "{app}\AltCrosshair.exe"; Description: "Starte AltCrosshair"; Flags: nowait postinstall skipifsilent
