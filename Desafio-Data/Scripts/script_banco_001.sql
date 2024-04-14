CREATE SEQUENCE "FIAP".users_id_seq START 1;
DROP TABLE IF EXISTS "FIAP".USERS;


CREATE SEQUENCE "FIAP".funcionarios_id_seq START 1;

DROP TABLE IF EXISTS "FIAP".FUNCIONARIOS;
CREATE TABLE "FIAP"."Funcionarios" (
	"Id" BIGINT PRIMARY KEY DEFAULT nextval('"FIAP".funcionarios_id_seq'),
	"Nome" VARCHAR(100),
	"Idade" INT,
	"Mae" VARCHAR(100),
	"Pai" VARCHAR(100)
);
CREATE INDEX idx_funcionarios_id ON "FIAP"."Funcionarios" ("Id");


CREATE SEQUENCE "FIAP".enderecos_id_seq START 1;

DROP TABLE IF EXISTS "FIAP"."Enderecos";
CREATE TABLE "FIAP"."Enderecos" (
    "Id" BIGINT PRIMARY KEY DEFAULT nextval('"FIAP".enderecos_id_seq'),
    "FuncionarioId" BIGINT not null,
    "Rua" VARCHAR(100),
    "Numero" INT8,
    "Cep" VARCHAR(10),
    "Cidade" VARCHAR(100),
    "Estado" VARCHAR(20)
);
CREATE INDEX idx_enderecos_id ON "FIAP"."Enderecos" ("Id");
CREATE INDEX idx_enderecoss_funcid ON "FIAP"."Enderecos" ("FuncionarioId");
ALTER TABLE "FIAP"."Enderecos" ADD CONSTRAINT "fk_Enderecos_FuncId" FOREIGN KEY ("FuncionarioId") REFERENCES "FIAP"."Funcionarios"("Id");


CREATE SEQUENCE "FIAP".entrevistas_id_seq START 1;

DROP TABLE IF EXISTS "FIAP"."Entrevistas";

create table "FIAP"."Entrevistas" (
	"Id" bigint primary key default nextval('"FIAP".entrevistas_id_seq'),
	"FuncionarioId" BIGINT,
	"Empresa" varchar(100),
	"DataEntrevista" date,
	"Salario" numeric(10,2),
	"Responsavel" varchar(100)	
);
CREATE INDEX idx_entrevistas_id ON "FIAP"."Entrevistas" ("Id");
CREATE INDEX idx_entrevistas_funcid ON "FIAP"."Entrevistas" ("FuncionarioId");
ALTER TABLE "FIAP"."Entrevistas" ADD CONSTRAINT "fk_Entrevistas_FuncId" FOREIGN KEY ("FuncionarioId") REFERENCES "FIAP"."Funcionarios"("Id");