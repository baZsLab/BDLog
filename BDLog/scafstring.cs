﻿using BDELog.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

//Scaffold-DbContext "User Id=TESTDB;Password=ABC;Data Source=localhost:1521/orcl;" Oracle.EntityFrameworkCore -OutputDir Models -Force -Tables B_ROLE,B_ROLECLAIMS,B_USER,B_USERCLAIMS,B_USERLOGINS,B_USERROLES,B_USERTOKENS,BDPF_AREA,BDPF_BDPFMA,BDPF_BLOG,BDPF_CAUSECODE,BDPF_CELL,BDPF_CONTMEAS,BDPF_CONTMEASURECODE,BDPF_DAMAGECODE,BDPF_EM,BDPF_FAULT,BDPF_IDA,BDPF_MAINT,BDPF_MC,BDPF_MCSUBUNIT,BDPF_MCUNIT,BDPF_OP,BDPF_PAPER -Context "BD_Context" -DataAnnotation -project BDELog -startupproject BDELog -ContextDir Contexts