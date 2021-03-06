USE [master]
GO
/****** Object:  Database [Hackathon]    Script Date: 21/10/2018 10:48:05 ******/
CREATE DATABASE [Hackathon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hackathon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Hackathon.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hackathon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Hackathon_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Hackathon] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hackathon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hackathon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hackathon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hackathon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hackathon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hackathon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hackathon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hackathon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hackathon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hackathon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hackathon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hackathon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hackathon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hackathon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hackathon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hackathon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hackathon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hackathon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hackathon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hackathon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hackathon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hackathon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hackathon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hackathon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hackathon] SET  MULTI_USER 
GO
ALTER DATABASE [Hackathon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hackathon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hackathon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hackathon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hackathon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hackathon] SET QUERY_STORE = OFF
GO
USE [Hackathon]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Hackathon]
GO
/****** Object:  User [Afave]    Script Date: 21/10/2018 10:48:05 ******/
CREATE USER [Afave] FOR LOGIN [Afave] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Afave]
GO
/****** Object:  UserDefinedFunction [dbo].[fcTrim]    Script Date: 21/10/2018 10:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fcTrim] 
(
	@Value VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	
	SET @Value = REPLACE(@Value, '
	','');

	SET @Value = REPLACE(REPLACE(@Value, CHAR(13), ''), CHAR(10), '');

	SET @Value = LTRIM(RTRIM(@Value));


	RETURN @Value
END
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 21/10/2018 10:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Split]
(
    @String NVARCHAR(4000),
    @Delimiter NCHAR(1)
)
RETURNS TABLE
AS
RETURN
(
    WITH Split(stpos,endpos)
    AS(
        SELECT 0 AS stpos, CHARINDEX(@Delimiter,@String) AS endpos
        UNION ALL
        SELECT endpos+1, CHARINDEX(@Delimiter,@String,endpos+1)
            FROM Split
            WHERE endpos > 0
    )
    SELECT 'Id' = ROW_NUMBER() OVER (ORDER BY (SELECT 1)),
        'Data' = SUBSTRING(@String,stpos,COALESCE(NULLIF(endpos,0),LEN(@String)+1)-stpos)
    FROM Split
)
GO
/****** Object:  Table [dbo].[EscolaMediaNota]    Script Date: 21/10/2018 10:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EscolaMediaNota](
	[CodigoEscola] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[CodigoTipoEnsino] [int] NOT NULL,
	[MediaNota] [numeric](6, 2) NOT NULL,
 CONSTRAINT [PK_ProvaBrasil_1] PRIMARY KEY CLUSTERED 
(
	[CodigoEscola] ASC,
	[Ano] ASC,
	[CodigoTipoEnsino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EscolaNEE]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EscolaNEE](
	[CodigoEscola] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[QtdAlunoEducacaoEspecial] [int] NOT NULL,
	[QtdAlunoEducacaoExpecializadaAEE] [int] NOT NULL,
 CONSTRAINT [PK_EscolaNEE] PRIMARY KEY CLUSTERED 
(
	[CodigoEscola] ASC,
	[Ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escolas]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escolas](
	[CodigoEscola] [int] NOT NULL,
	[CodigoTipoEscola] [int] NOT NULL,
	[NomeEscola] [varchar](255) NOT NULL,
	[CodigoMunicipio] [int] NOT NULL,
	[Cidade] [varchar](255) NOT NULL,
	[UF] [varchar](2) NOT NULL,
	[Logradouro] [varchar](100) NULL,
	[Numero] [int] NULL,
	[Bairro] [varchar](100) NULL,
	[Latitude] [varchar](50) NULL,
	[Longitude] [varchar](50) NULL,
 CONSTRAINT [PK_Escolas_1] PRIMARY KEY CLUSTERED 
(
	[CodigoEscola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEnsino]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEnsino](
	[CodigoTipoEnsino] [int] IDENTITY(1,1) NOT NULL,
	[NomeTipoEnsino] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoEsino] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoEnsino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEscola]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEscola](
	[CodigoTipoEscola] [int] IDENTITY(1,1) NOT NULL,
	[NomeTipoEscola] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoEscola] PRIMARY KEY CLUSTERED 
(
	[CodigoTipoEscola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EscolaMediaNota]  WITH CHECK ADD  CONSTRAINT [FK_ProvaBrasil_Escolas1] FOREIGN KEY([CodigoEscola])
REFERENCES [dbo].[Escolas] ([CodigoEscola])
GO
ALTER TABLE [dbo].[EscolaMediaNota] CHECK CONSTRAINT [FK_ProvaBrasil_Escolas1]
GO
ALTER TABLE [dbo].[EscolaMediaNota]  WITH CHECK ADD  CONSTRAINT [FK_ProvaBrasil_TipoEsino] FOREIGN KEY([CodigoTipoEnsino])
REFERENCES [dbo].[TipoEnsino] ([CodigoTipoEnsino])
GO
ALTER TABLE [dbo].[EscolaMediaNota] CHECK CONSTRAINT [FK_ProvaBrasil_TipoEsino]
GO
ALTER TABLE [dbo].[EscolaNEE]  WITH CHECK ADD  CONSTRAINT [FK_EscolaNEE_Escolas] FOREIGN KEY([CodigoEscola])
REFERENCES [dbo].[Escolas] ([CodigoEscola])
GO
ALTER TABLE [dbo].[EscolaNEE] CHECK CONSTRAINT [FK_EscolaNEE_Escolas]
GO
ALTER TABLE [dbo].[Escolas]  WITH CHECK ADD  CONSTRAINT [FK_Escolas_TipoEscola] FOREIGN KEY([CodigoTipoEscola])
REFERENCES [dbo].[TipoEscola] ([CodigoTipoEscola])
GO
ALTER TABLE [dbo].[Escolas] CHECK CONSTRAINT [FK_Escolas_TipoEscola]
GO
/****** Object:  StoredProcedure [dbo].[spGetEstado]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetEstado]
	
AS
BEGIN
	
	SELECT 
		UF 
	FROM 
		dbo.Escolas
	GROUP BY 
		UF
	ORDER BY 
		UF

END
GO
/****** Object:  StoredProcedure [dbo].[spGetMunicipios]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetMunicipios]
	@UF VARCHAR(2) =NULL
AS
BEGIN
	
	SELECT 
		CodigoMunicipio, 
		Cidade
	FROM
		dbo.Escolas
	WHERE 
		(@UF IS NULL OR UF = @UF)
	GROUP BY 
		CodigoMunicipio,
		Cidade
	ORDER BY 
		Cidade
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetRankingEscolas]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetRankingEscolas]
	@Ano INT,
	@Uf CHAR(2) = NULL,
	@CodigoMunicipio INT = NULL,
	@CodigoTipoEscola INT = NULL,
	@CodigoTipoEnsino INT = NULL,
	@TemNee BIT = NULL
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT 
		e.NomeEscola,
		tes.NomeTipoEscola,
		emn.MediaNota,
		(
			CASE
				WHEN ISNULL(enee.QtdAlunoEducacaoEspecial, 0) > 0 AND ISNULL(enee.QtdAlunoEducacaoExpecializadaAEE, 0) > 0
				THEN 'Possui aluno com educ. especial e especializada'
				WHEN ISNULL(enee.QtdAlunoEducacaoEspecial, 0) > 0
				THEN 'Possui aluno com educ. especial'
				WHEN ISNULL(enee.QtdAlunoEducacaoExpecializadaAEE, 0) > 0
				THEN 'Possui aluno com educ. especializada'
				ELSE 'Sem dados'
			END
		) AS TemEducacaoNee
	FROM
		dbo.Escolas AS e
	INNER JOIN 
		dbo.TipoEscola AS tes ON
			tes.CodigoTipoEscola = e.CodigoTipoEscola
	LEFT JOIN 
		dbo.EscolaMediaNota AS emn ON
			emn.CodigoEscola = e.CodigoEscola
	LEFT JOIN
		dbo.TipoEnsino AS ten ON
			ten.CodigoTipoEnsino = emn.CodigoTipoEnsino
	LEFT JOIN
		dbo.EscolaNEE AS enee ON
			enee.CodigoEscola = e.CodigoEscola
		AND enee.Ano = emn.Ano
	WHERE
		(@Ano IS NULL OR emn.Ano = @Ano)
	AND (@Uf IS NULL OR e.UF = @Uf)
	AND (@CodigoMunicipio IS NULL OR e.CodigoMunicipio = @CodigoMunicipio)
	AND (@CodigoTipoEscola IS NULL OR e.CodigoTipoEscola = @CodigoTipoEscola)
	AND (@CodigoTipoEnsino IS NULL OR emn.CodigoTipoEnsino = @CodigoTipoEnsino)
	AND (
			@TemNee IS NULL 
		OR	(
				(@TemNee = 1 AND (ISNULL(enee.QtdAlunoEducacaoEspecial, 0) > 0 OR ISNULL(enee.QtdAlunoEducacaoExpecializadaAEE, 0) > 0))
			OR	(@TemNee = 0 AND (ISNULL(enee.QtdAlunoEducacaoEspecial, 0) > 0 AND ISNULL(enee.QtdAlunoEducacaoExpecializadaAEE, 0) > 0))
			)
		)
	ORDER BY 
		emn.MediaNota,
		e.NomeEscola

END
GO
/****** Object:  StoredProcedure [dbo].[spGetTipoEnsino]    Script Date: 21/10/2018 10:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetTipoEnsino]
AS
BEGIN
	
	SELECT
		CodigoTipoEnsino,
        NomeTipoEnsino
	FROM
		dbo.TipoEnsino

END
GO
USE [master]
GO
ALTER DATABASE [Hackathon] SET  READ_WRITE 
GO
