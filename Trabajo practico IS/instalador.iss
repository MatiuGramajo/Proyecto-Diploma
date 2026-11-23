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
OutputBaseFilename=Setup_JMASolutions
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
Filename: "{cmd}"; Parameters: "/C net start MSSQLSERVER & net start MSSQL$SQLEXPRESS & net start MSSQL$SQLEXPRESS01"; Flags: runhidden; StatusMsg: "Iniciando servicio de base de datos..."
Filename: "sqlcmd.exe"; Parameters: "-S . -E -f 65001 -i ""{app}\InstalacionDB.sql"""; StatusMsg: "Configurando base de datos en instancia local..."; Flags: runhidden waituntilterminated skipifdoesntexist
Filename: "sqlcmd.exe"; Parameters: "-S .\SQLEXPRESS -E -f 65001 -i ""{app}\InstalacionDB.sql"""; StatusMsg: "Configurando base de datos en SQLEXPRESS..."; Flags: runhidden waituntilterminated skipifdoesntexist
Filename: "sqlcmd.exe"; Parameters: "-S .\SQLEXPRESS01 -E -f 65001 -i ""{app}\InstalacionDB.sql"""; StatusMsg: "Configurando base de datos en SQLEXPRESS01..."; Flags: runhidden waituntilterminated skipifdoesntexist
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
const
  SC_MANAGER_CONNECT = $0001;
  SERVICE_QUERY_STATUS = $0004;
  SERVICE_START = $0010;
  SERVICE_STOPPED = $00000001;
  SERVICE_RUNNING = $00000004;

type
  TServiceStatus = record
    dwServiceType: DWORD;
    dwCurrentState: DWORD;
    dwControlsAccepted: DWORD;
    dwWin32ExitCode: DWORD;
    dwServiceSpecificExitCode: DWORD;
    dwCheckPoint: DWORD;
    dwWaitHint: DWORD;
  end;

function OpenSCManagerW(lpMachineName, lpDatabaseName: string; dwDesiredAccess: DWORD): THandle;
  external 'OpenSCManagerW@advapi32.dll stdcall';
function OpenServiceW(hSCManager: THandle; lpServiceName: string; dwDesiredAccess: DWORD): THandle;
  external 'OpenServiceW@advapi32.dll stdcall';
function QueryServiceStatus(hService: THandle; var lpServiceStatus: TServiceStatus): BOOL;
  external 'QueryServiceStatus@advapi32.dll stdcall';
function StartServiceW(hService: THandle; dwNumServiceArgs: DWORD; lpServiceArgVectors: Longint): BOOL;
  external 'StartServiceW@advapi32.dll stdcall';
function CloseServiceHandle(hSCObject: THandle): BOOL;
  external 'CloseServiceHandle@advapi32.dll stdcall';

function VerificarMotorEnVistaRegistro(RootKey: Integer): Boolean;
var
  Subclaves, Valores: TArrayOfString;
  I: Integer;
  RutaBinarios: string;
begin
  Result := False;

  // 1. Verificar si existe al menos una instancia registrada en Instance Names\SQL
  if RegGetValueNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', Valores) then
  begin
    if GetArrayLength(Valores) > 0 then
    begin
      Result := True;
      Exit;
    end;
  end;

  // 2. Verificar subclaves de motor (ej: MSSQL15.SQLEXPRESS, MSSQL16.MSSQLSERVER)
  // y confirmar que el ejecutable físico sqlservr.exe exista en el disco
  if RegGetSubkeyNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server', Subclaves) then
  begin
    for I := 0 to GetArrayLength(Subclaves) - 1 do
    begin
      if Pos('MSSQL', Uppercase(Subclaves[I])) = 1 then
      begin
        if RegQueryStringValue(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server\' + Subclaves[I] + '\Setup', 'SQLBinRoot', RutaBinarios) then
        begin
          if FileExists(AddBackslash(RutaBinarios) + 'sqlservr.exe') then
          begin
            Result := True;
            Exit;
          end;
        end;
      end;
    end;
  end;

  // 3. Verificar si tiene instalado SQL Server LocalDB
  if RegGetSubkeyNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions', Subclaves) then
  begin
    if GetArrayLength(Subclaves) > 0 then
    begin
      Result := True;
      Exit;
    end;
  end;
end;

// Verifica si existe el motor o componentes base de SQL Server en el sistema
function ExisteMotorSQL(): Boolean;
begin
  Result := False;

  if IsWin64 then
    Result := VerificarMotorEnVistaRegistro(HKLM64);

  if not Result then
    Result := VerificarMotorEnVistaRegistro(HKLM32);
end;

// Consulta si el servicio existe y devuelve su estado actual
function ObtenerEstadoServicio(NombreServicio: string; var Estado: DWORD): Boolean;
var
  hSCM, hSvc: THandle;
  Status: TServiceStatus;
begin
  Result := False;
  hSCM := OpenSCManagerW('', '', SC_MANAGER_CONNECT);
  if hSCM <> 0 then
  begin
    hSvc := OpenServiceW(hSCM, NombreServicio, SERVICE_QUERY_STATUS);
    if hSvc <> 0 then
    begin
      if QueryServiceStatus(hSvc, Status) then
      begin
        Estado := Status.dwCurrentState;
        Result := True;
      end;
      CloseServiceHandle(hSvc);
    end;
    CloseServiceHandle(hSCM);
  end;
end;

// Habilita (si estaba deshabilitado) e inicia el servicio de SQL Server
function IniciarServicioSQL(NombreServicio: string): Boolean;
var
  hSCM, hSvc: THandle;
  Status: TServiceStatus;
  TipoInicio: Cardinal;
  Intentos: Integer;
begin
  Result := False;

  if RegQueryDWordValue(HKLM, 'SYSTEM\CurrentControlSet\Services\' + NombreServicio, 'Start', TipoInicio) then
  begin
    if TipoInicio = 4 then
      RegWriteDWordValue(HKLM, 'SYSTEM\CurrentControlSet\Services\' + NombreServicio, 'Start', 2);
  end;

  hSCM := OpenSCManagerW('', '', SC_MANAGER_CONNECT);
  if hSCM <> 0 then
  begin
    hSvc := OpenServiceW(hSCM, NombreServicio, SERVICE_QUERY_STATUS or SERVICE_START);
    if hSvc <> 0 then
    begin
      if StartServiceW(hSvc, 0, 0) then
      begin
        for Intentos := 1 to 20 do
        begin
          Sleep(500);
          if QueryServiceStatus(hSvc, Status) then
          begin
            if Status.dwCurrentState = SERVICE_RUNNING then
            begin
              Result := True;
              Break;
            end;
          end;
        end;
      end;
      CloseServiceHandle(hSvc);
    end;
    CloseServiceHandle(hSCM);
  end;
end;

// CASO 1: Revisa una instancia puntual; si está detenida, avisa y la activa
function VerificarYActivarServicio(NombreServicio: string; var ExisteInstancia: Boolean): Boolean;
var
  Estado: DWORD;
begin
  Result := True;

  if ObtenerEstadoServicio(NombreServicio, Estado) then
  begin
    ExisteInstancia := True;

    if Estado = SERVICE_STOPPED then
    begin
      MsgBox('Atención: El servicio de SQL Server (' + NombreServicio + ') se encuentra detenido.' + #13#10 + #13#10 +
             'El instalador procederá a activarlo automáticamente para continuar.', mbInformation, MB_OK);

      if IniciarServicioSQL(NombreServicio) then
      begin
        MsgBox('El servicio ' + NombreServicio + ' se inició correctamente.', mbInformation, MB_OK);
        Result := True;
      end
      else
      begin
        MsgBox('Error: No se pudo iniciar automáticamente el servicio ' + NombreServicio + '.' + #13#10 +
               'Inicielo manualmente desde Servicios de Windows (services.msc) y vuelva a ejecutar el instalador.', mbError, MB_OK);
        Result := False;
      end;
    end;
  end;
end;

procedure ActivarInstanciasDesdeRegistro(RootKey: Integer; var ExisteInstancia: Boolean; var ErrorCritico: Boolean);
var
  Valores: TArrayOfString;
  I: Integer;
  NombreServicio: string;
begin
  if RegGetValueNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', Valores) then
  begin
    for I := 0 to GetArrayLength(Valores) - 1 do
    begin
      if Uppercase(Valores[I]) = 'MSSQLSERVER' then
        NombreServicio := 'MSSQLSERVER'
      else
        NombreServicio := 'MSSQL$' + Valores[I];

      if not VerificarYActivarServicio(NombreServicio, ExisteInstancia) then
      begin
        ErrorCritico := True;
        Exit;
      end;
    end;
  end;
end;

function InitializeSetup(): Boolean;
var
  Mensaje: String;
  Respuesta: Integer;
  ExisteInstancia: Boolean;
  ErrorCritico: Boolean;
begin
  ExisteInstancia := False;
  ErrorCritico := False;

  // 1. CASO 1: Comprobar instancias y activarlas si están detenidas
  if IsWin64 then
    ActivarInstanciasDesdeRegistro(HKLM64, ExisteInstancia, ErrorCritico);
  if (not ErrorCritico) and (not ExisteInstancia) then
    ActivarInstanciasDesdeRegistro(HKLM32, ExisteInstancia, ErrorCritico);
  if ErrorCritico then
  begin
    Result := False;
    Exit;
  end;

  // Si existe al menos una instancia válida y activa, continúa sin advertencias
  if ExisteInstancia then
  begin
    Result := True;
    Exit;
  end;

  // 2. CASO 2 vs CASO 3: No hay instancia activa; verificamos si al menos existe el motor
  if ExisteMotorSQL() then
  begin
    // CASO 2: Existe el motor/componentes de SQL Server, pero no una instancia compatible
    Mensaje := 'Atención: Se detectó el motor de Microsoft SQL Server en este equipo, pero no se encontró ninguna instancia compatible (predeterminada o SQLEXPRESS).' + #13#10 + #13#10 +
               'El sistema JMA Solutions requiere una instancia activa para configurar y conectar su base de datos.' + #13#10 +
               'Puedes configurar una instancia o descargar SQL Server Express desde: https://www.microsoft.com/es-es/sql-server/sql-server-downloads' + #13#10 + #13#10 +
               '¿Deseas continuar con la instalación de todas formas?';

    Respuesta := MsgBox(Mensaje, mbConfirmation, MB_YESNO);
    Result := (Respuesta = IDYES);
  end
  else
  begin
    // CASO 3: No existe el motor de SQL Server en el equipo
    Mensaje := 'Advertencia: No se ha detectado el motor de Microsoft SQL Server instalado en este equipo.' + #13#10 + #13#10 +
               'El sistema JMA Solutions requiere el motor de base de datos SQL Server para funcionar.' + #13#10 +
               'Puedes descargarlo gratuitamente desde: https://www.microsoft.com/es-es/sql-server/sql-server-downloads' + #13#10 + #13#10 +
               '¿Deseas continuar con la instalación de todas formas?';

Respuesta := MsgBox(Mensaje, mbError, MB_YESNO);    Result := (Respuesta = IDYES);
  end;
end;