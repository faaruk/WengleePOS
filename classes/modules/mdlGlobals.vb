Module mdlGlobals
    Public Currency As String = "$"

    Public Session As String = "2014-15"

    Function DeveloperPc() As Boolean 
        Return My.Computer.Name.ToUpper = "USER-PC" Or My.Computer.Name.ToUpper = "BIDYUT-LAPTOP"
    End Function

End Module
