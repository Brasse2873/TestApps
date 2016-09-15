$        open/write out SFTP_FROMADITRO_GET_'MY_PID'.CMD
$        write out "lcd cabs_ss_dat"
$        write out "cd FilesToCABS"
$        write out "get ''FileFromAditroFilter'.txt"
$        close out
$        sftp "-B"SFTP_FROMADITRO_GET_'MY_PID'.CMD "''SFTP_ADITRO_USER'@''SFTP_ADITRO_NODE'"
