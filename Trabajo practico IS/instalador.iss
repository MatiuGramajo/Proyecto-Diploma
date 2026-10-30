
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
; Non-commercial use only

#define MyAppName "JMA Solutions"
#define MyAppVersion "1.5"  
#define MyAppPublisher "My Company, Inc."
#define MyAppURL "https://www.example.com/"
#define MyAppExeName "Trabajo practico IS.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8FFB4ED1-0B7C-4766-9374-C55B9DFCCF15}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Privilegios de administrador requeridos para que SQL Server no tire error de permisos
PrivilegesRequired=admin
OutputBaseFilename=mysetup
SolidCompression=yes
WizardStyle=modern dynamic

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\Trabajo practico IS\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\Trabajo practico IS\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\InstalacionDB.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\SQL2025-SSEI-Expr.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{tmp}\SQL2025-SSEI-Expr.exe"; Parameters: "/QS /IACCEPTSQLSERVERLICENSETERMS /ACTION=Install /FEATURES=SQLEngine /INSTANCENAME=SQLEXPRESS01 /SQLSVCACCOUNT=""NT AUTHORITY\Network Service"" /SQLSYSADMINACCOUNTS=""BUILTIN\ADMINISTRATORS"""; Check: NeedsSQLServer; StatusMsg: "Instalando motor de Base de Datos (Esto puede demorar unos minutardos)..."
Filename: "{cmd}"; Parameters: "/C net start MSSQL$SQLEXPRESS01"; Flags: runhidden; StatusMsg: "Iniciando servicio de base de datos..."
Filename: "sqlcmd.exe"; Parameters: "-S .\SQLEXPRESS01 -E -b -i ""{app}\InstalacionDB.sql"""; StatusMsg: "Configurando base de datos..."; Flags: runhidden waituntilterminated runascurrentuser
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function NeedsSQLServer(): Boolean;
var
  sqlInstalled: Cardinal;
begin
  if RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server\SQLEXPRESS01\MSSQLServer\CurrentVersion', 'CurrentMajorVersionNumber', sqlInstalled) then
  begin
    Result := False; 
  end
  else
  begin
    Result := True;
  end;
end;