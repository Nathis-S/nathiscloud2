sts = GetAdaptersInfo(AdapInfo, bufLen)
   If (bufLen = 0) Then Exit Function
   numStructs = bufLen / Len(AdapInfo)

   ReDim IPinfoBuf(0 To bufLen - 1) As Byte
   sts = GetAdaptersInfo(IPinfoBuf(0), bufLen)
   If (sts <> 0) Then Exit Function

   srcPtr = VarPtr(IPinfoBuf(0))
   For i = 0 To numStructs - 1
   If (srcPtr = 0) Then Exit For
      CopyMemory AdapInfo, ByVal srcPtr, Len(AdapInfo)

      With AdapInfo
         If (.AdapterType = MIB_IF_TYPE_ETHERNET) Then
            retStr = retStr & MAC2String(.MACaddress) & " "
         End If
      End With

      srcPtr = AdapInfo.Next
   Next i