<?php
	session_start();
	include 'dbserver.php';
		//Client
 	$Username	= $_POST["user"];
	$filtraLogin = filter_var($Username, FILTER_SANITIZE_SPECIAL_CHARS);
	$filtraLogin = filter_var($filtraLogin, FILTER_SANITIZE_MAGIC_QUOTES);

	$Password	= $_POST["pass"];
	$filtraSenha = filter_var($Password, FILTER_SANITIZE_SPECIAL_CHARS);
	$filtraSenha = filter_var($filtraSenha, FILTER_SANITIZE_MAGIC_QUOTES);


	function criptoSenha($criptoSenha){//md5
		return md5($criptoSenha);
	}

	$criptoSenha = criptoSenha($filtraSenha);
	$sql = "SELECT * FROM users WHERE email = '$filtraLogin' AND senha = '$criptoSenha'";
	
	$consultaInformacoes = mysqli_query($conn, $sql);
	$verificaInformacoes = $consultaInformacoes->num_rows;

	if($verificaInformacoes == 1){ //
		while($result = mysqli_fetch_array($consultaInformacoes)){
			$_SESSION['nome_usuario']=$result['nome'];
			//echo ("true");
			echo $result['nome']."|".$result['imagem']."|".$result['email'];
			/*
			echo $result['email']."\n";
			echo $result['imagem']."\n";
			*/

		}
	}
	else{
		echo("false");
	}

	//echo $name;



?>