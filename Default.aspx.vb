Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Net
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim dbs As New SqlConnection, cmd As New SqlCommand, rst As SqlDataReader
    Dim aSQL As String, oMSG As String, Result As String, oDATA As String = "", oSTOCK As Long, oIDTRX As String
    ReadOnly DBHost As String = "localhost"
    ReadOnly DBName As String = "dbsSurvey"
    ReadOnly DBUser As String = "usersurvey"
    ReadOnly DBPass As String = "usersurvey"
    ReadOnly CONStr As String = "Server=" & DBHost & ";Database=" & DBName & ";User Id=" & DBUser & ";Password=" & DBPass & ";MultipleActiveResultSets=True"
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim action As String = Request("action")
        Select Case action
            Case "login"
                Dim oINIT As String = Request("user")
                Dim oPASS As String = Request("password")
                Response.Write(LOGIN(oINIT, oPASS))
            Case "loginsimpan"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oINIT As String = Request("init")
                Dim oNAMA As String = Request("nama")
                Dim oPASS As String = Request("password")
                Dim oHAK As String = Request("level")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(LOGIN_SIMPAN(oINIT, oNAMA, oPASS, oHAK))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "loginubah"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oINIT As String = Request("init")
                Dim oNAMA As String = Request("nama")
                Dim oHAK As String = Request("level")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(LOGIN_UBAH(oUSER, oINIT, oNAMA, oHAK))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "logingantipass"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oPASS As String = Request("password")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(LOGIN_UBAHPASS(oUSER, oPASS))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "loginnonaktif"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oINIT As String = Request("init")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(LOGIN_NONAKTIF(oUSER, oINIT))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "loginlist"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(LOGIN_LIST())
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "surveysimpan"
                Dim oNAMA As String = Request("nama")
                Dim oALAMAT As String = Request("alamat")
                Dim oCAMAT As String = Request("kecamatan")
                Dim oLURAH As String = Request("kelurahan")
                Dim oRT As String = Request("rt")
                Dim oRW As String = Request("rw")
                Dim oHP As String = Request("nohp")
                Dim oPENGHUNI As String = Request("penghuni")
                Dim oDAYA As String = Request("daya")
                Dim oUSAHA As String = Request("usaha")
                Dim oJARINGAN As String = Request("jaringan")
                Dim oJARAK As String = Request("jarak")
                Dim oLOKASI As String = Request("lokasi")
                Dim oKTP As String = Request("ktp")
                Dim oBANGUNAN As String = Request("luasbangunan")
                Dim oNOMETER As String = Request("nometer")
                Dim oKET As String = Request("keterangan")
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(SURVEY_SIMPAN(oNAMA, oALAMAT, oCAMAT, oLURAH, oRT, oRW, oHP, oPENGHUNI, oDAYA, oUSAHA, oJARINGAN, oJARAK, oLOKASI, oKTP, oBANGUNAN, oNOMETER, oKET, oUSER))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "surveyubah"
                Dim oNAMA As String = Request("nama")
                Dim oALAMAT As String = Request("alamat")
                Dim oCAMAT As String = Request("kecamatan")
                Dim oLURAH As String = Request("kelurahan")
                Dim oRT As String = Request("rt")
                Dim oRW As String = Request("rw")
                Dim oHP As String = Request("nohp")
                Dim oPENGHUNI As String = Request("penghuni")
                Dim oDAYA As String = Request("daya")
                Dim oUSAHA As String = Request("usaha")
                Dim oJARINGAN As String = Request("jaringan")
                Dim oJARAK As String = Request("jarak")
                Dim oKTP As String = Request("ktp")
                Dim oBANGUNAN As String = Request("luasbangunan")
                Dim oNOMETER As String = Request("nometer")
                Dim oKET As String = Request("keterangan")
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(SURVEY_UBAH(oKTP, oNAMA, oALAMAT, oCAMAT, oLURAH, oRT, oRW, oHP, oPENGHUNI, oDAYA, oUSAHA, oJARINGAN, oJARAK, oBANGUNAN, oNOMETER, oKET, oUSER))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "surveydetail"
                Dim oKTP As String = Request("ktp")
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(SURVEY_DETAIL(oKTP))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "surveylist"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oBULAN As String = Request("bulan")
                Dim oTAHUN As String = Request("tahun")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(SURVEY_LIST(oUSER, oBULAN, oTAHUN))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "kecamatanlist"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(CAMAT_LIST())
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "kelurahanlist"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oCAMAT As String = Request("idcamat")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(LURAH_LIST(oCAMAT))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "simpanfoto"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oKTP As String = Request("ktp")
                Dim oJENIS As String = Request("jenis")
                Dim oPHOTO As HttpPostedFile = Request.Files("fileupload")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(_SIMPANFOTO(oKTP, oJENIS, oPHOTO))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "tampilfoto"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oKTP As String = Request("ktp")
                Dim oJENIS As String = Request("jenis")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    Response.Write(_TAMPILFOTO2(oKTP, oJENIS))
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
            Case "getphoto"
                Dim oUSER As String = Request("user")
                Dim oPASSUSER As String = Request("passuser")
                Dim oKTP As String = Request("ktp")
                Dim oJENIS As String = Request("jenis")
                If LOGINAUTH(oUSER, oPASSUSER) = True Then
                    _TAMPILFOTO(oKTP, oJENIS)
                Else
                    Response.Write(ERROR_MESSAGE("Not Allowed"))
                End If
        End Select
    End Sub
#Region "LOGIN"
    Private Function LOGIN_UBAHPASS(oUSER As String, oPASS As String) As String
        If Len(oUSER) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oPASS) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                aSQL = "update tbllogin set password='" & oPASS & "' where username='" & oUSER & "'"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.Connection.Open()
                cmd.CommandText = aSQL
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                Result = "{""status"":0}"
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function LOGIN_UBAH(oUSER As String, oINIT As String, oNAMA As String, oHAK As String) As String
        If Len(oUSER) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oINIT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oNAMA) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oHAK) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                aSQL = "Select Nama from tbllogin where username='" & oINIT & "' and HakAkses < 9"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                If rst.Read Then
                    rst.Close()
                    aSQL = "update tbllogin set Nama='" & oNAMA & "',HakAkses='" & oHAK & "' where username='" & oINIT & "'"
                    cmd.CommandText = aSQL
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Result = "{""status"":0}"
                Else
                    Result = "{""status"":1,""msg"":""User Tidak Ditemukan""}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function LOGIN_NONAKTIF(oUSER As String, oINIT As String) As String
        If Len(oUSER) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oINIT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                If UCase(oUSER) = UCase(oINIT) Then
                    Result = ERROR_MESSAGE("Not Allowed")
                Else
                    aSQL = "Select Nama from tbllogin where username='" & oINIT & "' and HakAkses < 9"
                    dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                    cmd.Connection = dbs
                    cmd.CommandType = Data.CommandType.Text
                    cmd.CommandText = aSQL
                    cmd.Connection.Open()
                    rst = cmd.ExecuteReader
                    If rst.Read Then
                        rst.Close()
                        aSQL = "update tbllogin set hakakses=9 where username='" & oINIT & "'"
                        cmd.CommandText = aSQL
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                        Result = "{""status"":0}"
                    Else
                        Result = "{""status"":1,""msg"":""User Tidak Ditemukan""}"
                    End If
                    rst.Close() : cmd.Connection.Close()
                End If
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function LOGIN_SIMPAN(oINIT As String, oNAMA As String, oPASS As String, oHAK As String) As String
        If Len(oINIT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oNAMA) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oPASS) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oHAK) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                aSQL = "Select Nama,password,HakAkses from tbllogin where username='" & oINIT & "'"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                If rst.Read Then
                    Result = "{""status"":1,""msg"":""User Ditemukan""}"
                Else
                    rst.Close()
                    aSQL = "insert into tblLogin values ('" & UCase(oINIT) & "','" & oPASS & "','" & oNAMA & "'," & oHAK & ")"
                    cmd.CommandText = aSQL
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Result = "{""status"":0}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function LOGINAUTH(oUSER As String, oPASS As String) As Boolean
        Dim oAUTH As Boolean = True, oPASSDB As String = ""
        If Len(oUSER) < 1 Then oAUTH = False
        If Len(oPASS) < 1 Then oAUTH = False
        If Not oAUTH = False Then
            aSQL = "Select password from tbllogin where username='" & oUSER & "' AND HakAkses < 9"
            dbs = New System.Data.SqlClient.SqlConnection(CONStr)
            cmd.Connection = dbs
            cmd.CommandType = Data.CommandType.Text
            cmd.CommandText = aSQL
            cmd.Connection.Open()
            rst = cmd.ExecuteReader
            If rst.Read Then
                If Not IsDBNull(rst!password) Then oPASSDB = Trim(rst!password)
                If Trim(oPASS) = Trim(oPASSDB) Then
                    oAUTH = True
                Else
                    oAUTH = False
                End If
            Else
                oAUTH = False
            End If
            rst.Close() : cmd.Connection.Close()
        End If
        Return oAUTH
    End Function
    Private Function LOGIN_LIST() As String
        Dim oUSER As String = "", oNAMA As String = "", oLEVEL As String = ""
        Try
            aSQL = "Select Username,Nama,HakAkses from tbllogin "
            dbs = New System.Data.SqlClient.SqlConnection(CONStr)
            cmd.Connection = dbs
            cmd.CommandType = Data.CommandType.Text
            cmd.CommandText = aSQL
            cmd.Connection.Open()
            rst = cmd.ExecuteReader
            Do While rst.Read
                If Not IsDBNull(rst!Username) Then oUSER = UCase(Trim(rst!Username)) Else oUSER = ""
                If Not IsDBNull(rst!Nama) Then oNAMA = UCase(Trim(rst!Nama)) Else oNAMA = ""
                If Not IsDBNull(rst!HakAkses) Then oLEVEL = Trim(rst!HakAkses) Else oLEVEL = ""
                oDATA &= "{""username"":""" & oUSER &
                                          """,""nama"":""" & oNAMA &
                                          """,""level"":" & oLEVEL & "},"
            Loop
            If IsNothing(oDATA) Or Len(oDATA) < 2 Then
                Result = "{""status"":1,""msg"":""User Tidak Ditemukan""}"
            Else
                Result = "{""status"":0,""data"":[" & oDATA.Substring(0, Len(oDATA) - 1) & "]}"
            End If
            rst.Close() : cmd.Connection.Close()
        Catch ex As Exception
            Result = ERROR_MESSAGE("Invalid")
        End Try
        Return Result
    End Function
    Private Function LOGIN(oINIT As String, oPASS As String) As String
        Dim oPASSDB As String = "", oHAK As String = "", oNAMA As String = ""
        If Len(oINIT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oPASS) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                aSQL = "Select Nama,password,HakAkses from tbllogin where username='" & oINIT & "'"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                If rst.Read Then
                    If Not IsDBNull(rst!Nama) Then oNAMA = Trim(rst!Nama)
                    If Not IsDBNull(rst!password) Then oPASSDB = Trim(rst!password)
                    If Not IsDBNull(rst!HakAkses) Then oHAK = Trim(rst!HakAkses)
                    If Trim(oPASS) = Trim(oPASSDB) Then
                        Result = "{""status"":0,""nama"":""" & oNAMA & """,""level"":" & oHAK & "}"
                    Else
                        Result = "{""status"":1,""msg"":""User Tidak Ditemukan""}"
                    End If
                Else
                    Result = "{""status"":1,""msg"":""User Tidak Ditemukan""}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
#End Region
#Region "SURVEY"
    Private Function _SIMPANFOTO(oKTP As String, oJENIS As String, oPHOTO As HttpPostedFile) As String
        Dim oPATH As String, aFName As String
        'METODE MENANGKAP BASE64 DENGAN API
        If Len(oKTP) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oJENIS) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                oPATH = Server.MapPath("\dev\survey\FotoSurvey\" & oKTP) 'PRODUCTION
                'oPATH = Server.MapPath("~\FotoSurvey")
                aFName = oJENIS & "_" & oKTP & ".JPG"
                If Not System.IO.Directory.Exists(oPATH) Then
                    System.IO.Directory.CreateDirectory(oPATH)
                End If
                Try
                    If oPHOTO IsNot Nothing AndAlso oPHOTO.ContentLength > 0 Then
                        If Not File.Exists(oPATH & "\" & aFName) Then
                            oPHOTO.SaveAs(oPATH & "\" & aFName)
                        Else
                            File.Delete(oPATH & "\" & aFName)
                            oPHOTO.SaveAs(oPATH & "\" & aFName)
                        End If
                    End If
                    If File.Exists(oPATH & "\" & aFName) Then
                        Result = "{""status"":0}"
                    Else
                        Result = ERROR_MESSAGE("err(FileNotFound)")
                    End If
                Catch ex As Exception
                    Result = ERROR_MESSAGE("Invalid")
                End Try
            Catch ex As Exception
                Result = ERROR_MESSAGE("err(file)")
            End Try
        End If
        Return Result
    End Function
    Private Function SURVEY_LIST(oUSER As String, oBULAN As String, oTAHUN As String) As String
        Dim oLEVEL As String, oNAMA As String, oALAMAT As String, oHP As String, oPENGHUNI As String, oDAYA As String
        Dim oUSAHA As String, oJARINGAN As String, oJARAK As String, oLOKASI As String, oKTP As String, oTGL As String
        Try
            aSQL = "Select HakAkses from tbllogin where username='" & oUSER & "'"
            dbs = New System.Data.SqlClient.SqlConnection(CONStr)
            cmd.Connection = dbs
            cmd.CommandType = Data.CommandType.Text
            cmd.CommandText = aSQL
            cmd.Connection.Open()
            rst = cmd.ExecuteReader
            If rst.Read Then
                If Not IsDBNull(rst!hakakses) Then oLEVEL = Trim(rst!hakAkses) Else oLEVEL = 9
                If oLEVEL = 9 Then
                    Result = ERROR_MESSAGE("Not Allowed")
                Else
                    rst.Close()
                    If oLEVEL = 0 Then 'admin
                        aSQL = "Select Survey_Nama,Survey_Alamat,Survey_NoHP,Survey_Ktp,Survey_Penghuni,Survey_Daya,Survey_Usaha,Survey_Jaringan,"
                        aSQL &= "Survey_Jarak,Survey_Lokasi,Survey_Tanggal from tblSurvey where month(Survey_Tanggal)=" & oBULAN & " "
                        aSQL &= "and year(Survey_Tanggal)=" & oTAHUN & " order by Survey_Tanggal desc "
                        cmd.CommandText = aSQL
                        rst = cmd.ExecuteReader
                        Do While rst.Read
                            If Not IsDBNull(rst!Survey_Nama) Then oNAMA = Trim(rst!Survey_Nama) Else oNAMA = ""
                            If Not IsDBNull(rst!Survey_Alamat) Then oALAMAT = Trim(rst!Survey_Alamat) Else oALAMAT = ""
                            If Not IsDBNull(rst!Survey_NoHP) Then oHP = Trim(rst!Survey_NoHP) Else oHP = ""
                            If Not IsDBNull(rst!Survey_Ktp) Then oKTP = Trim(rst!Survey_Ktp) Else oKTP = ""
                            If Not IsDBNull(rst!Survey_Penghuni) Then oPENGHUNI = Trim(rst!Survey_Penghuni) Else oPENGHUNI = "null"
                            If Not IsDBNull(rst!Survey_Daya) Then oDAYA = Trim(rst!Survey_Daya) Else oDAYA = "null"
                            If Not IsDBNull(rst!Survey_Usaha) Then oUSAHA = Trim(rst!Survey_Usaha) Else oUSAHA = ""
                            If Not IsDBNull(rst!Survey_Jaringan) Then oJARINGAN = Trim(rst!Survey_Jaringan) Else oJARINGAN = ""
                            If Not IsDBNull(rst!Survey_Jarak) Then oJARAK = Trim(rst!Survey_Jarak) Else oJARAK = "null"
                            If Not IsDBNull(rst!Survey_Lokasi) Then oLOKASI = Trim(rst!Survey_Lokasi) Else oLOKASI = ""
                            If Not IsDBNull(rst!Survey_Tanggal) Then oTGL = Format(CDate(Trim(rst!Survey_Tanggal)), "yyyy-MM-dd") Else oTGL = ""
                            If oUSAHA = 0 Then
                                oUSAHA = "Tidak ada"
                            ElseIf oUSAHA = 1 Then
                                oUSAHA = "ada"
                            End If
                            If oJARINGAN = 0 Then
                                oJARINGAN = "Tidak ada"
                            ElseIf oJARINGAN = 1 Then
                                oJARINGAN = "ada"
                            End If
                            oDATA &= "{""ktp"":" & oKTP &
                                         ",""nama"":""" & oNAMA &
                                         """,""alamat"":""" & oALAMAT &
                                         """,""handphone"":""" & oHP &
                                         """,""penghuni"":" & oPENGHUNI &
                                         ",""daya"":" & oDAYA &
                                         ",""usaha"":""" & oUSAHA &
                                         """,""jaringan"":""" & oJARINGAN &
                                         """,""jarak"":" & oJARAK &
                                         ",""lokasi"":""" & oLOKASI &
                                         """,""tanggal"":""" & oTGL & """},"
                        Loop
                    ElseIf oLEVEL = 1 Then 'user
                        aSQL = "Select Survey_Nama,Survey_Alamat,Survey_NoHP,Survey_Ktp,Survey_Penghuni,Survey_Daya,Survey_Usaha,Survey_Jaringan,"
                        aSQL &= "Survey_Jarak,Survey_Lokasi,Survey_Tanggal from tblSurvey where Survey_init='" & oUSER & "' "
                        aSQL &= "and month(Survey_Tanggal)=" & oBULAN & " and year(Survey_Tanggal)=" & oTAHUN & " order by Survey_Tanggal desc "
                        cmd.CommandText = aSQL
                        rst = cmd.ExecuteReader
                        Do While rst.Read
                            If Not IsDBNull(rst!Survey_Nama) Then oNAMA = Trim(rst!Survey_Nama) Else oNAMA = ""
                            If Not IsDBNull(rst!Survey_Alamat) Then oALAMAT = Trim(rst!Survey_Alamat) Else oALAMAT = ""
                            If Not IsDBNull(rst!Survey_NoHP) Then oHP = Trim(rst!Survey_NoHP) Else oHP = ""
                            If Not IsDBNull(rst!Survey_Ktp) Then oKTP = Trim(rst!Survey_Ktp) Else oKTP = ""
                            If Not IsDBNull(rst!Survey_Penghuni) Then oPENGHUNI = Trim(rst!Survey_Penghuni) Else oPENGHUNI = "null"
                            If Not IsDBNull(rst!Survey_Daya) Then oDAYA = Trim(rst!Survey_Daya) Else oDAYA = "null"
                            If Not IsDBNull(rst!Survey_Usaha) Then oUSAHA = Trim(rst!Survey_Usaha) Else oUSAHA = ""
                            If Not IsDBNull(rst!Survey_Jaringan) Then oJARINGAN = Trim(rst!Survey_Jaringan) Else oJARINGAN = ""
                            If Not IsDBNull(rst!Survey_Jarak) Then oJARAK = Trim(rst!Survey_Jarak) Else oJARAK = "null"
                            If Not IsDBNull(rst!Survey_Lokasi) Then oLOKASI = Trim(rst!Survey_Lokasi) Else oLOKASI = ""
                            If Not IsDBNull(rst!Survey_Tanggal) Then oTGL = Format(CDate(Trim(rst!Survey_Tanggal)), "yyyy-MM-dd") Else oTGL = ""
                            If oUSAHA = 0 Then
                                oUSAHA = "Tidak ada"
                            ElseIf oUSAHA = 1 Then
                                oUSAHA = "ada"
                            End If
                            If oJARINGAN = 0 Then
                                oJARINGAN = "Tidak ada"
                            ElseIf oJARINGAN = 1 Then
                                oJARINGAN = "ada"
                            End If
                            oDATA &= "{""ktp"":" & oKTP &
                                         ",""nama"":""" & oNAMA &
                                         """,""alamat"":""" & oALAMAT &
                                         """,""handphone"":""" & oHP &
                                         """,""penghuni"":" & oPENGHUNI &
                                         ",""daya"":" & oDAYA &
                                         ",""usaha"":""" & oUSAHA &
                                         """,""jaringan"":""" & oJARINGAN &
                                         """,""jarak"":" & oJARAK &
                                         ",""lokasi"":""" & oLOKASI &
                                         """,""tanggal"":""" & oTGL & """},"
                        Loop
                    End If
                    If IsNothing(oDATA) Or Len(oDATA) < 2 Then
                        Result = "{""status"":1,""msg"":""Survey Tidak Ditemukan""}"
                    Else
                        Result = "{""status"":0,""data"":[" & oDATA.Substring(0, Len(oDATA) - 1) & "]}"
                    End If
                    rst.Close() : cmd.Connection.Close()
                End If
            Else
                Result = ERROR_MESSAGE("Not Allowed")
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result = ERROR_MESSAGE("Invalid")
        End Try
        Return Result
    End Function
    Private Function SURVEY_SIMPAN(oNAMA As String, oALAMAT As String, oCAMAT As String, oLURAH As String, oRT As String, oRW As String, oHP As String, oPENGHUNI As String, oDAYA As String,
                                       oUSAHA As String, oJARINGAN As String, oJARAK As String, oLOKASI As String, oKTP As String, oBANGUNAN As String, oNOMETER As String, oKET As String, oINIT As String) As String
        Dim oJAM As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        If Len(oKTP) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oNAMA) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oALAMAT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oCAMAT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oLURAH) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oINIT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                If Len(oHP) > 0 Then oHP = "'" & oHP & "'" Else oHP = "null"
                If Len(oPENGHUNI) > 0 Then oPENGHUNI = oPENGHUNI Else oPENGHUNI = "null"
                If Len(oDAYA) > 0 Then oDAYA = oDAYA Else oDAYA = "null"
                If Len(oJARAK) > 0 Then oJARAK = oJARAK Else oJARAK = "null"
                If Len(oLOKASI) > 0 Then oLOKASI = "'" & oLOKASI & "'" Else oLOKASI = "null"
                If Len(oRT) > 0 Then oRT = oRT Else oRT = "0"
                If Len(oRW) > 0 Then oRW = oRW Else oRW = "0"
                If Len(oBANGUNAN) > 0 Then oBANGUNAN = "'" & Trim(oBANGUNAN) & "'" Else oBANGUNAN = "null"
                If Len(oNOMETER) > 0 Then oNOMETER = "'" & Trim(oNOMETER) & "'" Else oNOMETER = "null"
                If Len(oKET) > 0 Then oKET = "'" & Trim(oKET) & "'" Else oKET = "null"
                If oUSAHA = "Ada" Then oUSAHA = 1 Else oUSAHA = 0
                If oJARINGAN = "Ada" Then oJARINGAN = 1 Else oJARINGAN = 0
                aSQL = "Select Survey_Nama from tblSurvey where Survey_Ktp='" & oKTP & "'"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                If rst.Read Then
                    Result = "{""status"":1,""msg"":""Data dengan Ktp " & oKTP & " telah terdaftar""}"
                Else
                    rst.Close()
                    aSQL = "INSERT INTO tblSurvey (Survey_Nama,Survey_Alamat,Kodecamat,Kodelurah,Survey_RT,Survey_RW,Survey_NoHP,Survey_Ktp,Survey_Penghuni,"
                    aSQL &= "Survey_Daya,Survey_Usaha,Survey_Jaringan,Survey_Jarak,Survey_Lokasi,Survey_Bangunan,Survey_Nometer,Survey_Keterangan,Survey_Tanggal,Survey_Init) "
                    aSQL &= "VALUES ('" & oNAMA & "','" & oALAMAT & "'," & oCAMAT & "," & oLURAH & "," & oRT & "," & oRW & "," & oHP & ",'" & oKTP & "'," & oPENGHUNI & ","
                    aSQL &= oDAYA & "," & oUSAHA & "," & oJARINGAN & "," & oJARAK & "," & oLOKASI & "," & oBANGUNAN & "," & oNOMETER & "," & oKET & ",'" & oJAM & "','" & oINIT & "')"
                    cmd.CommandText = aSQL
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Result = "{""status"":0}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function SURVEY_UBAH(oKTP As String, oNAMA As String, oALAMAT As String, oCAMAT As String, oLURAH As String, oRT As String, oRW As String, oHP As String, oPENGHUNI As String, oDAYA As String,
                                     oUSAHA As String, oJARINGAN As String, oJARAK As String, oBANGUNAN As String, oNOMETER As String, oKET As String, oUSER As String) As String
        Dim oJAM As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        If Len(oKTP) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oNAMA) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oALAMAT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oCAMAT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oLURAH) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oUSER) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                If Len(oHP) > 0 Then oHP = "'" & oHP & "'" Else oHP = "null"
                If Len(oPENGHUNI) > 0 Then oPENGHUNI = oPENGHUNI Else oPENGHUNI = "null"
                If Len(oDAYA) > 0 Then oDAYA = oDAYA Else oDAYA = "null"
                If Len(oJARAK) > 0 Then oJARAK = oJARAK Else oJARAK = "null"
                If oUSAHA = "Ada" Then oUSAHA = 1 Else oUSAHA = 0
                If oJARINGAN = "Ada" Then oJARINGAN = 1 Else oJARINGAN = 0
                If Len(oRT) > 0 Then oRT = oRT Else oRT = "0"
                If Len(oRW) > 0 Then oRW = oRW Else oRW = "0"
                If Len(oBANGUNAN) > 0 Then oBANGUNAN = "'" & Trim(oBANGUNAN) & "'" Else oBANGUNAN = "null"
                If Len(oNOMETER) > 0 Then oNOMETER = "'" & Trim(oNOMETER) & "'" Else oNOMETER = "null"
                If Len(oKET) > 0 Then oKET = "'" & Trim(oKET) & "'" Else oKET = "null"
                aSQL = "Select Survey_Nama from tblSurvey where Survey_Ktp='" & oKTP & "'"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                If rst.Read Then
                    rst.Close()
                    aSQL = "UPDATE tblSurvey set Survey_Nama='" & oNAMA & "',Survey_Alamat='" & oALAMAT & "',Kodecamat=" & oCAMAT & ",Kodelurah=" & oLURAH & ",Survey_RT=" & oRT & ",Survey_RW=" & oRW & ",Survey_NoHP=" & oHP & ",Survey_Penghuni=" & oPENGHUNI & ","
                    aSQL &= "Survey_Daya=" & oDAYA & ",Survey_Usaha=" & oUSAHA & ",Survey_Jaringan=" & oJARINGAN & ",Survey_Jarak=" & oJARAK & ",Survey_Bangunan=" & oBANGUNAN & ",Survey_Nometer=" & oNOMETER & ",Survey_Keterangan=" & oKET & " "
                    aSQL &= ",Survey_TanggalEdit='" & oJAM & "' where Survey_Ktp='" & oKTP & "'"
                    cmd.CommandText = aSQL
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Result = "{""status"":0}"
                Else
                    Result = "{""status"":1,""msg"":""Data Tidak Ditemukan""}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function SURVEY_DETAIL(oKTP As String) As String
        Dim oNAMA As String, oALAMAT As String, oHP As String, oPENGHUNI As String, oDAYA As String
        Dim oUSAHA As String, oJARINGAN As String, oJARAK As String, oLOKASI As String, oBANGUNAN As String, oNOMETER As String, oKET As String, oTGL As String
        Dim iCAMAT As String, oCAMAT As String
        Dim iLURAH As String, oLURAH As String
        Dim oRT As String, oRW As String
        If Len(oKTP) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                aSQL = "Select Survey_Nama,Survey_Alamat,Kodecamat,Kodelurah,Survey_RT,Survey_RW,Survey_NoHP,Survey_Penghuni,Survey_Daya,Survey_Usaha,Survey_Jaringan,"
                aSQL &= "Survey_Jarak,Survey_Lokasi,Survey_Bangunan,Survey_Nometer,Survey_Keterangan,Survey_Tanggal from tblSurvey where Survey_Ktp='" & oKTP & "'"
                cmd.CommandText = aSQL
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                If rst.Read Then
                    If Not IsDBNull(rst!Survey_Nama) Then oNAMA = Trim(rst!Survey_Nama) Else oNAMA = ""
                    If Not IsDBNull(rst!Survey_Alamat) Then oALAMAT = Trim(rst!Survey_Alamat) Else oALAMAT = ""
                    If Not IsDBNull(rst!Kodecamat) Then iCAMAT = Trim(rst!Kodecamat) Else iCAMAT = "0"
                    If Not IsDBNull(rst!Kodelurah) Then iLURAH = Trim(rst!Kodelurah) Else iLURAH = "0"
                    If Not IsDBNull(rst!Survey_RT) Then oRT = Trim(rst!Survey_RT) Else oRT = "null"
                    If Not IsDBNull(rst!Survey_RW) Then oRW = Trim(rst!Survey_RW) Else oRW = "null"
                    If Not IsDBNull(rst!Survey_NoHP) Then oHP = Trim(rst!Survey_NoHP) Else oHP = ""
                    If Not IsDBNull(rst!Survey_Penghuni) Then oPENGHUNI = Trim(rst!Survey_Penghuni) Else oPENGHUNI = "null"
                    If Not IsDBNull(rst!Survey_Daya) Then oDAYA = Trim(rst!Survey_Daya) Else oDAYA = "null"
                    If Not IsDBNull(rst!Survey_Usaha) Then oUSAHA = Trim(rst!Survey_Usaha) Else oUSAHA = ""
                    If Not IsDBNull(rst!Survey_Jaringan) Then oJARINGAN = Trim(rst!Survey_Jaringan) Else oJARINGAN = ""
                    If Not IsDBNull(rst!Survey_Jarak) Then oJARAK = Trim(rst!Survey_Jarak) Else oJARAK = "null"
                    If Not IsDBNull(rst!Survey_Lokasi) Then oLOKASI = Trim(rst!Survey_Lokasi) Else oLOKASI = ""
                    If Not IsDBNull(rst!Survey_Bangunan) Then oBANGUNAN = """" & Trim(rst!Survey_Bangunan) & """" Else oBANGUNAN = "null"
                    If Not IsDBNull(rst!Survey_Nometer) Then oNOMETER = """" & Trim(rst!Survey_Nometer) & """" Else oNOMETER = "null"
                    If Not IsDBNull(rst!Survey_Keterangan) Then oKET = """" & Trim(rst!Survey_Keterangan) & """" Else oKET = "null"
                    If Not IsDBNull(rst!Survey_Tanggal) Then oTGL = Format(CDate(Trim(rst!Survey_Tanggal)), "yyyy-MM-dd") Else oTGL = ""
                    rst.Close()
                    aSQL = "Select kecamatan from tblcamat where kodecamat=" & iCAMAT
                    cmd.CommandText = aSQL
                    rst = cmd.ExecuteReader
                    If rst.Read Then
                        If Not IsDBNull(rst!kecamatan) Then oCAMAT = """" & Trim(rst!kecamatan) & """" Else oCAMAT = "null"
                    Else
                        iCAMAT = "null"
                    End If
                    rst.Close()
                    aSQL = "Select kelurahan from tbllurah where kodelurah=" & iLURAH
                    cmd.CommandText = aSQL
                    rst = cmd.ExecuteReader
                    If rst.Read Then
                        If Not IsDBNull(rst!kelurahan) Then oLURAH = """" & Trim(rst!kelurahan) & """" Else oLURAH = "null"
                    Else
                        iLURAH = "null"
                    End If
                    rst.Close()
                    Result = "{""status"":0,""nama"":""" & oNAMA &
                                   """,""alamat"":""" & oALAMAT &
                                    """,""id_kecamatan"":" & iCAMAT &
                                   ",""id_kelurahan"":" & iLURAH &
                                   ",""kecamatan"":" & oCAMAT &
                                   ",""kelurahan"":" & oLURAH &
                                   ",""rt"":" & oRT &
                                   ",""rw"":" & oRW &
                                   ",""handphone"":""" & oHP &
                                   """,""penghuni"":" & oPENGHUNI &
                                   ",""daya"":" & oDAYA &
                                   ",""usaha"":""" & oUSAHA &
                                   """,""jaringan"":""" & oJARINGAN &
                                   """,""jarak"":" & oJARAK &
                                   ",""luasbangunan"":" & oBANGUNAN &
                                   ",""nometer"":" & oNOMETER &
                                   ",""keterangan"":" & oKET &
                                   ",""lokasi"":""" & oLOKASI &
                                   """,""tanggal"":""" & oTGL & """}"
                Else
                    Result = "{""status"":1,""msg"":""Survey Tidak Ditemukan""}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
    Private Function CAMAT_LIST() As String
        Dim oKODE As String, oCAMAT As String
        Try
            aSQL = "Select kodecamat,kecamatan from tblcamat order by kodecamat"
            dbs = New System.Data.SqlClient.SqlConnection(CONStr)
            cmd.Connection = dbs
            cmd.CommandType = Data.CommandType.Text
            cmd.CommandText = aSQL
            cmd.Connection.Open()
            rst = cmd.ExecuteReader
            Do While rst.Read
                If Not IsDBNull(rst!kodecamat) Then oKODE = Trim(rst!kodecamat) Else oKODE = ""
                If Not IsDBNull(rst!kecamatan) Then oCAMAT = Trim(rst!kecamatan) Else oCAMAT = ""
                oDATA &= "{""id"":" & oKODE & ",""kecamatan"":""" & oCAMAT & """},"
            Loop
            If IsNothing(oDATA) Or Len(oDATA) < 2 Then
                Result = "{""status"":1,""msg"":""Survey Tidak Ditemukan""}"
            Else
                Result = "{""status"":0,""data"":[" & oDATA.Substring(0, Len(oDATA) - 1) & "]}"
            End If
            rst.Close() : cmd.Connection.Close()
        Catch ex As Exception
            Result = ERROR_MESSAGE("Invalid")
        End Try
        Return Result
    End Function
    Private Function LURAH_LIST(oCAMAT As String) As String
        Dim oKODE As String, oLURAH As String
        If Len(oCAMAT) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Try
                aSQL = "Select kodelurah,kelurahan from tbllurah where kodecamat=" & oCAMAT & " order by kodelurah"
                dbs = New System.Data.SqlClient.SqlConnection(CONStr)
                cmd.Connection = dbs
                cmd.CommandType = Data.CommandType.Text
                cmd.CommandText = aSQL
                cmd.Connection.Open()
                rst = cmd.ExecuteReader
                Do While rst.Read
                    If Not IsDBNull(rst!kodelurah) Then oKODE = Trim(rst!kodelurah) Else oKODE = ""
                    If Not IsDBNull(rst!kelurahan) Then oLURAH = Trim(rst!kelurahan) Else oLURAH = ""
                    oDATA &= "{""id"":" & oKODE & ",""kelurahan"":""" & oLURAH & """},"
                Loop
                If IsNothing(oDATA) Or Len(oDATA) < 2 Then
                    Result = "{""status"":1,""msg"":""Survey Tidak Ditemukan""}"
                Else
                    Result = "{""status"":0,""data"":[" & oDATA.Substring(0, Len(oDATA) - 1) & "]}"
                End If
                rst.Close() : cmd.Connection.Close()
            Catch ex As Exception
                Result = ERROR_MESSAGE("Invalid")
            End Try
        End If
        Return Result
    End Function
#End Region
#Region "UTILITY"
    Protected Sub _TAMPILFOTO(oKTP As String, oJENIS As String)
        Dim oPATH As String, oFNAME As String
        If Len(oKTP) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oJENIS) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If IsNothing(Result) Or Len(Result) < 2 Then
            Dim client As New WebClient() : Dim buffer As [Byte]()
            oPATH = Server.MapPath("\dev\survey\FotoSurvey\" & oKTP) 'PRODUCTION
            'oPATH = Server.MapPath("\FotoSurvey\" & oKTP) 'LOCAL
            oFNAME = oJENIS & "_" & oKTP & ".JPG"
            If Not System.IO.File.Exists(oPATH & "\" & oFNAME) Then
                oPATH = Server.MapPath("\FotoSurvey")
                oFNAME = "noimage.jpg"
            End If
            buffer = client.DownloadData(oPATH & "\" & oFNAME)
            If buffer IsNot Nothing Then
                Response.ContentType = "image/jpeg"
                Response.AddHeader("content-length", buffer.Length.ToString())
                Response.BinaryWrite(buffer)
            End If
        Else
            Response.Write(Result)
        End If
    End Sub
    Private Function _TAMPILFOTO2(oKTP As String, oJENIS As String) As String
        Dim oPATH As String, oFNAME As String
        Dim image_base64String As String
        If Len(oKTP) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")
        If Len(oJENIS) < 1 Then Result = ERROR_MESSAGE("Data Param Tidak Ada")

        If IsNothing(Result) Or Len(Result) < 2 Then
            oPATH = Server.MapPath("\dev\survey\FotoSurvey\" & oKTP) 'PRODUCTION
            'oPATH = Server.MapPath("\FotoSurvey\" & oKTP)
            oFNAME = oJENIS & "_" & oKTP & ".JPG"
            If System.IO.File.Exists(oPATH & "\" & oFNAME) Then
                'Nih kalo Ketemu
                Using tImage As Bitmap = Image.FromFile(oPATH & "\" & oFNAME)
                    Dim ms As New MemoryStream
                    tImage.Save(ms, Imaging.ImageFormat.Jpeg)
                    Dim bytes() As Byte = ms.ToArray
                    image_base64String = Convert.ToBase64String(bytes)
                End Using
                Result = "{""status"":0,""data"":""data:image/jpg;base64," & image_base64String & """}"
            End If
        End If
        '..
        Return Result
    End Function
    Function ERROR_MESSAGE(oMSG As String) As String
        Return "{""status"":9,""msg"":""" & oMSG & """}"
    End Function
#End Region

End Class
