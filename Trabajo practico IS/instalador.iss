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
AppId={{8FFB4ED1-0B7C-4766-9374-C55B9DFCCF15}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
PrivilegesRequired=admin
OutputBaseFilename=mysetup
SolidCompression=yes
WizardStyle=modern dynamic

[Messages]
SetupAppTitle=JMASolution Setup
SetupWindowTitle=JMASolution Setup
[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


[Files]
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\Trabajo practico IS\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\Trabajo practico IS\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\matias\OneDrive\Escritorio\Proyecto Diploma\Proyecto-Diploma\Trabajo practico IS\InstalacionDB.sql"; DestDir: "{app}"; Flags: ignoreversion

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; Si el usuario decide continuar aunque no tenga SQL, estas líneas intentarán crear la base de datos asumiendo que configurará algo manual después
Filename: "{cmd}"; Parameters: "/C net start MSSQL$SQLEXPRESS"; Flags: runhidden; StatusMsg: "Iniciando servicio de base de datos..."
Filename: "sqlcmd.exe"; Parameters: "-S .\SQLEXPRESS -E -b -i ""{app}\InstalacionDB.sql"""; StatusMsg: "Configurando base de datos..."; Flags: runhidden waituntilterminated runascurrentuser skipifdoesntexist
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function InitializeSetup(): Boolean;
var
  Mensaje: String;
  Respuesta: Integer;
begin
  // Buscamos si existe el servicio base de SQL Server en la PC.
  // Esta clave de servicio se crea siempre que se instala una instancia (como MSSQLSERVER o SQLEXPRESS).
  if RegKeyExists(HKLM, 'SYSTEM\CurrentControlSet\Services\MSSQLSERVER') or 
     RegKeyExists(HKLM, 'SYSTEM\CurrentControlSet\Services\MSSQL$SQLEXPRESS') or
     RegKeyExists(HKLM, 'SYSTEM\CurrentControlSet\Services\MSSQL$SQLEXPRESS01') then
  begin
    // Si encuentra algún servicio de SQL Server, avanzamos.
    Result := True;
  end
  else
  begin
    // Si NO hay instancias reales, mostramos la advertencia
    Mensaje := 'Atención: No se ha detectado ninguna instancia de Microsoft SQL Server en este equipo.' + #13#10 + #13#10 +
               'El sistema JMA Solutions requiere este motor de base de datos para funcionar correctamente.' + #13#10 +
               'Puedes descargar SQL Server Express gratuitamente desde: https://www.microsoft.com/es-es/sql-server/sql-server-downloads' + #13#10 + #13#10 +
               '¿Deseas continuar con la instalación de todas formas?';
               
    Respuesta := MsgBox(Mensaje, mbInformation, MB_YESNO);
    
    if Respuesta = IDYES then
      Result := True
    else
      Result := False;
  end;
end;