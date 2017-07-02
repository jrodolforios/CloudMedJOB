namespace MediCloud.Persistence
{
    using DatabaseModels;
    using System.Data.Entity;
    public partial class CloudMedContext : DbContext
    {
        public CloudMedContext()
            : base("name=MediCloudConnection")
        {
        }

        public virtual DbSet<CARGO> CARGO { get; set; }
        public virtual DbSet<INFORMACOES_CLINICA> INFORMACOES_CLINICA { get; set; }
        public virtual DbSet<CENTROCUSTO> CENTROCUSTO { get; set; }
        public virtual DbSet<CIDADE> CIDADE { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<CLIENTE_CONTATO> CLIENTE_CONTATO { get; set; }
        public virtual DbSet<CLIENTE_CREDIARIO> CLIENTE_CREDIARIO { get; set; }
        public virtual DbSet<CLIENTE_GRUPO> CLIENTE_GRUPO { get; set; }
        public virtual DbSet<CLIENTE_OUTRASEMP> CLIENTE_OUTRASEMP { get; set; }
        public virtual DbSet<COMPOSICOESCAIXA> COMPOSICOESCAIXA { get; set; }
        public virtual DbSet<CONTA_ORC> CONTA_ORC { get; set; }
        public virtual DbSet<CONTA_ORC_GRU> CONTA_ORC_GRU { get; set; }
        public virtual DbSet<CONTADOR> CONTADOR { get; set; }
        public virtual DbSet<CONTASORC> CONTASORC { get; set; }
        public virtual DbSet<CONTRATO_FIXO> CONTRATO_FIXO { get; set; }
        public virtual DbSet<CONTRATO_FIXO_DET> CONTRATO_FIXO_DET { get; set; }
        public virtual DbSet<EPCMSO> EPCMSO { get; set; }
        public virtual DbSet<EPPRA> EPPRA { get; set; }
        public virtual DbSet<FATURAMENTO> FATURAMENTO { get; set; }
        public virtual DbSet<FECHAMENTO_CAIXA> FECHAMENTO_CAIXA { get; set; }
        public virtual DbSet<FORMADEPAGAMENTO> FORMADEPAGAMENTO { get; set; }
        public virtual DbSet<FORNECEDOR> FORNECEDOR { get; set; }
        public virtual DbSet<FORNECEDOR_CONTATO> FORNECEDOR_CONTATO { get; set; }
        public virtual DbSet<FORNECEDORXPROCEDIMENTO> FORNECEDORXPROCEDIMENTO { get; set; }
        public virtual DbSet<FUNCIONARIO> FUNCIONARIO { get; set; }
        public virtual DbSet<HISCONFIRMACAO> HISCONFIRMACAO { get; set; }
        public virtual DbSet<LAUDOAUD> LAUDOAUD { get; set; }
        public virtual DbSet<LAUDOAV> LAUDOAV { get; set; }
        public virtual DbSet<LAUDORX> LAUDORX { get; set; }
        public virtual DbSet<LOGS> LOGS { get; set; }
        public virtual DbSet<LOG_ERRO> LOG_ERRO { get; set; }
        public virtual DbSet<MODELOLAUDO> MODELOLAUDO { get; set; }
        public virtual DbSet<MOVIMENTO> MOVIMENTO { get; set; }
        public virtual DbSet<MOVIMENTO_ARQUIVOS> MOVIMENTO_ARQUIVOS { get; set; }
        public virtual DbSet<MOVIMENTO_FECHAMENTO> MOVIMENTO_FECHAMENTO { get; set; }
        public virtual DbSet<MOVIMENTO_PROCEDIMENTO> MOVIMENTO_PROCEDIMENTO { get; set; }
        public virtual DbSet<MOVIMENTO_REFERENTE> MOVIMENTO_REFERENTE { get; set; }
        public virtual DbSet<NATUREZA> NATUREZA { get; set; }
        public virtual DbSet<NOTAFISCAL> NOTAFISCAL { get; set; }
        public virtual DbSet<PARAMETRO> PARAMETRO { get; set; }
        public virtual DbSet<PARAMETRO_TAB> PARAMETRO_TAB { get; set; }
        public virtual DbSet<PASTASMOV> PASTASMOV { get; set; }
        public virtual DbSet<PROCEDIMENTO> PROCEDIMENTO { get; set; }
        public virtual DbSet<PROCEDIMENTO_GRUPO> PROCEDIMENTO_GRUPO { get; set; }
        public virtual DbSet<PROCEDIMENTO_GRUPO_SUBGRUP> PROCEDIMENTO_GRUPO_SUBGRUP { get; set; }
        public virtual DbSet<PROFISSIONAIS> PROFISSIONAIS { get; set; }
        public virtual DbSet<RECOMENDACAO> RECOMENDACAO { get; set; }
        public virtual DbSet<RECOMENDACAOXASO> RECOMENDACAOXASO { get; set; }
        public virtual DbSet<RECOMENDACAOXASOXPRO> RECOMENDACAOXASOXPRO { get; set; }
        public virtual DbSet<RECOMENDACAOXRISCO> RECOMENDACAOXRISCO { get; set; }
        public virtual DbSet<RISCO> RISCO { get; set; }
        public virtual DbSet<ROTA> ROTA { get; set; }
        public virtual DbSet<SEGMENTO> SEGMENTO { get; set; }
        public virtual DbSet<SETOR> SETOR { get; set; }
        public virtual DbSet<SYS_CAIXA> SYS_CAIXA { get; set; }
        public virtual DbSet<SYS_CATEND> SYS_CATEND { get; set; }
        public virtual DbSet<SYS_CLASSES> SYS_CLASSES { get; set; }
        public virtual DbSet<SYS_COMSQL> SYS_COMSQL { get; set; }
        public virtual DbSet<SYS_CONCORRENCIA> SYS_CONCORRENCIA { get; set; }
        public virtual DbSet<SYS_CONSULTA> SYS_CONSULTA { get; set; }
        public virtual DbSet<SYS_FICHATECNICA> SYS_FICHATECNICA { get; set; }
        public virtual DbSet<SYS_HELP> SYS_HELP { get; set; }
        public virtual DbSet<SYS_HELPBODY> SYS_HELPBODY { get; set; }
        public virtual DbSet<SYS_KPI> SYS_KPI { get; set; }
        public virtual DbSet<SYS_LAYOUT> SYS_LAYOUT { get; set; }
        public virtual DbSet<SYS_LOGMSG> SYS_LOGMSG { get; set; }
        public virtual DbSet<SYS_LTELA> SYS_LTELA { get; set; }
        public virtual DbSet<SYS_MAIL> SYS_MAIL { get; set; }
        public virtual DbSet<SYS_REFRULES> SYS_REFRULES { get; set; }
        public virtual DbSet<SYS_REGINI> SYS_REGINI { get; set; }
        public virtual DbSet<SYS_REGRAS> SYS_REGRAS { get; set; }
        public virtual DbSet<SYS_REPORTS> SYS_REPORTS { get; set; }
        public virtual DbSet<SYS_USRCOLUMN> SYS_USRCOLUMN { get; set; }
        public virtual DbSet<SYS_USRCOMPONENT> SYS_USRCOMPONENT { get; set; }
        public virtual DbSet<SYS_USRFORM> SYS_USRFORM { get; set; }
        public virtual DbSet<SYS_USRFORMXTABLE> SYS_USRFORMXTABLE { get; set; }
        public virtual DbSet<SYS_USRON> SYS_USRON { get; set; }
        public virtual DbSet<SYS_USRTABLE> SYS_USRTABLE { get; set; }
        public virtual DbSet<SYS_USUARIO> SYS_USUARIO { get; set; }
        public virtual DbSet<TAB> TAB { get; set; }
        public virtual DbSet<TABELA> TABELA { get; set; }
        public virtual DbSet<TABELAXFORNECEDORXPROCEDIMENTO> TABELAXFORNECEDORXPROCEDIMENTO { get; set; }
        public virtual DbSet<AUDIOMETRIA> AUDIOMETRIA { get; set; }
        public virtual DbSet<BANCOS> BANCOS { get; set; }
        public virtual DbSet<CLIENTE_CONTRATOFIXO> CLIENTE_CONTRATOFIXO { get; set; }
        public virtual DbSet<CLIENTE_OCUPACIONAL> CLIENTE_OCUPACIONAL { get; set; }
        public virtual DbSet<CONTASBANCARIAS> CONTASBANCARIAS { get; set; }
        public virtual DbSet<CONTASPAGAR> CONTASPAGAR { get; set; }
        public virtual DbSet<CONTASRECEBER> CONTASRECEBER { get; set; }
        public virtual DbSet<CONTRATOSFORNEC> CONTRATOSFORNEC { get; set; }
        public virtual DbSet<LCTOSCAIXA> LCTOSCAIXA { get; set; }
        public virtual DbSet<LCTOSCONTAS> LCTOSCONTAS { get; set; }
        public virtual DbSet<SEQBANCOS> SEQBANCOS { get; set; }
        public virtual DbSet<SEQCARGO> SEQCARGO { get; set; }
        public virtual DbSet<SEQCENTROCUSTO> SEQCENTROCUSTO { get; set; }
        public virtual DbSet<SEQCIDADE> SEQCIDADE { get; set; }
        public virtual DbSet<SEQCLIENTE> SEQCLIENTE { get; set; }
        public virtual DbSet<SEQCLIENTE_CONTATO> SEQCLIENTE_CONTATO { get; set; }
        public virtual DbSet<SEQCLIENTE_CREDIARIO> SEQCLIENTE_CREDIARIO { get; set; }
        public virtual DbSet<SEQCLIENTE_GRUPO> SEQCLIENTE_GRUPO { get; set; }
        public virtual DbSet<SEQCLIENTE_OUTRASEMP> SEQCLIENTE_OUTRASEMP { get; set; }
        public virtual DbSet<SEQCOMPOSICOESCAIXA> SEQCOMPOSICOESCAIXA { get; set; }
        public virtual DbSet<SEQCONTA_ORC> SEQCONTA_ORC { get; set; }
        public virtual DbSet<SEQCONTA_ORC_GRU> SEQCONTA_ORC_GRU { get; set; }
        public virtual DbSet<SEQCONTADOR> SEQCONTADOR { get; set; }
        public virtual DbSet<SEQCONTASBANCARIAS> SEQCONTASBANCARIAS { get; set; }
        public virtual DbSet<SEQCONTASORC> SEQCONTASORC { get; set; }
        public virtual DbSet<SEQCONTASPAGAR> SEQCONTASPAGAR { get; set; }
        public virtual DbSet<SEQCONTASRECEBER> SEQCONTASRECEBER { get; set; }
        public virtual DbSet<SEQCONTRATO_FIXO> SEQCONTRATO_FIXO { get; set; }
        public virtual DbSet<SEQCONTRATO_FIXO_DET> SEQCONTRATO_FIXO_DET { get; set; }
        public virtual DbSet<SEQCONTRATOSFORNEC> SEQCONTRATOSFORNEC { get; set; }
        public virtual DbSet<SEQEPCMSO> SEQEPCMSO { get; set; }
        public virtual DbSet<SEQEPPRA> SEQEPPRA { get; set; }
        public virtual DbSet<SEQFATURAMENTO> SEQFATURAMENTO { get; set; }
        public virtual DbSet<SEQFECHAMENTO_CAIXA> SEQFECHAMENTO_CAIXA { get; set; }
        public virtual DbSet<SEQFORMADEPAGAMENTO> SEQFORMADEPAGAMENTO { get; set; }
        public virtual DbSet<SEQFORNECEDOR> SEQFORNECEDOR { get; set; }
        public virtual DbSet<SEQFORNECEDOR_CONTATO> SEQFORNECEDOR_CONTATO { get; set; }
        public virtual DbSet<SEQFUNCIONARIO> SEQFUNCIONARIO { get; set; }
        public virtual DbSet<SEQHISCONFIRMACAO> SEQHISCONFIRMACAO { get; set; }
        public virtual DbSet<SEQLAUDOAUD> SEQLAUDOAUD { get; set; }
        public virtual DbSet<SEQLAUDOAV> SEQLAUDOAV { get; set; }
        public virtual DbSet<SEQLCTOSCAIXA> SEQLCTOSCAIXA { get; set; }
        public virtual DbSet<SEQLCTOSCONTAS> SEQLCTOSCONTAS { get; set; }
        public virtual DbSet<SEQLOGS> SEQLOGS { get; set; }
        public virtual DbSet<SEQMODELOLAUDO> SEQMODELOLAUDO { get; set; }
        public virtual DbSet<SEQMOVIMENTO> SEQMOVIMENTO { get; set; }
        public virtual DbSet<SEQMOVIMENTO_ARQUIVOS> SEQMOVIMENTO_ARQUIVOS { get; set; }
        public virtual DbSet<SEQMOVIMENTO_FECHAMENTO> SEQMOVIMENTO_FECHAMENTO { get; set; }
        public virtual DbSet<SEQMOVIMENTO_PROCEDIMENTO> SEQMOVIMENTO_PROCEDIMENTO { get; set; }
        public virtual DbSet<SEQMOVIMENTO_REFERENTE> SEQMOVIMENTO_REFERENTE { get; set; }
        public virtual DbSet<SEQNATUREZA> SEQNATUREZA { get; set; }
        public virtual DbSet<SEQNOTAFISCAL> SEQNOTAFISCAL { get; set; }
        public virtual DbSet<SEQPARAMETRO> SEQPARAMETRO { get; set; }
        public virtual DbSet<SEQPASTASMOV> SEQPASTASMOV { get; set; }
        public virtual DbSet<SEQPROCEDIMENTO> SEQPROCEDIMENTO { get; set; }
        public virtual DbSet<SEQPROCEDIMENTO_GRUPO> SEQPROCEDIMENTO_GRUPO { get; set; }
        public virtual DbSet<SEQPROCEDIMENTO_GRUPO_SUBGRUP> SEQPROCEDIMENTO_GRUPO_SUBGRUP { get; set; }
        public virtual DbSet<SEQRECOMENDACAO> SEQRECOMENDACAO { get; set; }
        public virtual DbSet<SEQRECOMENDACAOXASO> SEQRECOMENDACAOXASO { get; set; }
        public virtual DbSet<SEQRECOMENDACAOXASOXPRO> SEQRECOMENDACAOXASOXPRO { get; set; }
        public virtual DbSet<SEQRECOMENDACAOXRISCO> SEQRECOMENDACAOXRISCO { get; set; }
        public virtual DbSet<SEQRISCO> SEQRISCO { get; set; }
        public virtual DbSet<SEQROTA> SEQROTA { get; set; }
        public virtual DbSet<SEQSEGMENTO> SEQSEGMENTO { get; set; }
        public virtual DbSet<SEQSETOR> SEQSETOR { get; set; }
        public virtual DbSet<SEQSYS_COMSQL> SEQSYS_COMSQL { get; set; }
        public virtual DbSet<SEQSYS_CONSULTA> SEQSYS_CONSULTA { get; set; }
        public virtual DbSet<SEQSYS_FICHATECNICA> SEQSYS_FICHATECNICA { get; set; }
        public virtual DbSet<SEQSYS_HELP> SEQSYS_HELP { get; set; }
        public virtual DbSet<SEQSYS_KPI> SEQSYS_KPI { get; set; }
        public virtual DbSet<SEQSYS_LAYOUT> SEQSYS_LAYOUT { get; set; }
        public virtual DbSet<SEQSYS_LOGMSG> SEQSYS_LOGMSG { get; set; }
        public virtual DbSet<SEQSYS_LTELA> SEQSYS_LTELA { get; set; }
        public virtual DbSet<SEQSYS_MAIL> SEQSYS_MAIL { get; set; }
        public virtual DbSet<SEQSYS_REPORTS> SEQSYS_REPORTS { get; set; }
        public virtual DbSet<SEQSYS_USRCOLUMN> SEQSYS_USRCOLUMN { get; set; }
        public virtual DbSet<SEQSYS_USRCOMPONENT> SEQSYS_USRCOMPONENT { get; set; }
        public virtual DbSet<SEQSYS_USRFORM> SEQSYS_USRFORM { get; set; }
        public virtual DbSet<SEQSYS_USRTABLE> SEQSYS_USRTABLE { get; set; }
        public virtual DbSet<SEQSYS_USUARIO> SEQSYS_USUARIO { get; set; }
        public virtual DbSet<SEQTABELA> SEQTABELA { get; set; }
        public virtual DbSet<SEQTEXTOPADRAO> SEQTEXTOPADRAO { get; set; }
        public virtual DbSet<SEQTIPOSCONTRATOS> SEQTIPOSCONTRATOS { get; set; }
        public virtual DbSet<SEQTIPOSDOCTOS> SEQTIPOSDOCTOS { get; set; }
        public virtual DbSet<SYS_CFGGER> SYS_CFGGER { get; set; }
        public virtual DbSet<SYS_USRLOG> SYS_USRLOG { get; set; }
        public virtual DbSet<SYS_USRXREL> SYS_USRXREL { get; set; }
        public virtual DbSet<TEXTOPADRAO> TEXTOPADRAO { get; set; }
        public virtual DbSet<TIPOSCONTRATOS> TIPOSCONTRATOS { get; set; }
        public virtual DbSet<TIPOSDOCTOS> TIPOSDOCTOS { get; set; }
        public virtual DbSet<CONT_MOV_CLI> CONT_MOV_CLI { get; set; }
        public virtual DbSet<EXPORTACAO_NF> EXPORTACAO_NF { get; set; }
        public virtual DbSet<MOV_PROC_COMPLETO> MOV_PROC_COMPLETO { get; set; }
        public virtual DbSet<QUANTIDADE_NOTAFISCAL> QUANTIDADE_NOTAFISCAL { get; set; }
        public virtual DbSet<SELECTANUAL> SELECTANUAL { get; set; }
        public virtual DbSet<selectultimomovcli> selectultimomovcli { get; set; }
        public virtual DbSet<SELECTULTIMOMOVCLIENTE> SELECTULTIMOMOVCLIENTE { get; set; }
        public virtual DbSet<SL_ACOMPANHAMENTO> SL_ACOMPANHAMENTO { get; set; }
        public virtual DbSet<SL_RECOMENDACAO> SL_RECOMENDACAO { get; set; }
        public virtual DbSet<SLCONSULTAMOVIMENTO> SLCONSULTAMOVIMENTO { get; set; }
        public virtual DbSet<slmovxrec> slmovxrec { get; set; }
        public virtual DbSet<SLNFCL> SLNFCL { get; set; }
        public virtual DbSet<SLNOTAFISCAL> SLNOTAFISCAL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CARGO>()
                .Property(e => e.IDCGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CARGO>()
                .Property(e => e.CARGO1)
                .IsUnicode(false);

            modelBuilder.Entity<CARGO>()
                .Property(e => e.ABREVIADO)
                .IsUnicode(false);

            modelBuilder.Entity<CARGO>()
                .Property(e => e.CODNEXO)
                .IsUnicode(false);

            modelBuilder.Entity<CARGO>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CARGO>()
                .HasMany(e => e.MOVIMENTO)
                .WithRequired(e => e.CARGO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CENTROCUSTO>()
                .Property(e => e.APELIDO)
                .IsUnicode(false);

            modelBuilder.Entity<CENTROCUSTO>()
                .Property(e => e.CEN_ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CENTROCUSTO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CENTROCUSTO>()
                .Property(e => e.NOTAS)
                .IsUnicode(false);

            modelBuilder.Entity<CENTROCUSTO>()
                .HasMany(e => e.LCTOSCAIXA)
                .WithOptional(e => e.CENTROCUSTO)
                .HasForeignKey(e => e.CODIGOCENTROCUSTO);

            modelBuilder.Entity<CIDADE>()
                .Property(e => e.IDCID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CIDADE>()
                .Property(e => e.CIDADE1)
                .IsUnicode(false);

            modelBuilder.Entity<CIDADE>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.TIPOCLIENTE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.ATIVIDADE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDROTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDSEG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDCONT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDEPPRA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDEPCMSO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.USUARIOATUALIZACAO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.CLIENTE_CREDIARIO)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.CLIENTE_OUTRASEMP)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.MOVIMENTO)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.TABELA)
                .WithMany(e => e.CLIENTE)
                .Map(m => m.ToTable("CLIENTE_TABELA").MapLeftKey("IDCLI").MapRightKey("IDTAB"));

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.IDCON)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.DEPARTAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.FUNCAO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.FONEFIXO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.FONEMOVEL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.OBS)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTATO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDCRE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDFEC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDCLIGRU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IMPRIME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.INSCESTADUAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.INSCMUNICIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDBBCOBRANCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.TIPOEMPRESA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.SACADO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.OBSNF)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDCID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.NF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.ENTREGA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CREDIARIO>()
                .Property(e => e.IDFORPAG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDCLIGRU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.GRUPO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.INSCESTADUAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.INSCMUNICIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IMPRIME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDFEC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDBBCOBRANCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.TIPOEMPRESA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.OBSNF)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDROTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDSEG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.TIPOCLIENTE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.NF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.ENTREGA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDFORPAG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_GRUPO>()
                .Property(e => e.IDCID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_OUTRASEMP>()
                .Property(e => e.IDEMP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_OUTRASEMP>()
                .Property(e => e.EMPRESA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_OUTRASEMP>()
                .Property(e => e.NOMERESP)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_OUTRASEMP>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_OUTRASEMP>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<COMPOSICOESCAIXA>()
                .Property(e => e.CODIGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<COMPOSICOESCAIXA>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<COMPOSICOESCAIXA>()
                .Property(e => e.NOTAS)
                .IsUnicode(false);

            modelBuilder.Entity<COMPOSICOESCAIXA>()
                .HasMany(e => e.LCTOSCAIXA)
                .WithRequired(e => e.COMPOSICOESCAIXA)
                .HasForeignKey(e => e.CODIGOCOMPCX)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTA_ORC>()
                .Property(e => e.IDCTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTA_ORC>()
                .Property(e => e.NUMCTAORC)
                .HasPrecision(10, 0);

            modelBuilder.Entity<CONTA_ORC>()
                .Property(e => e.NOMECONTAORC)
                .IsUnicode(false);

            modelBuilder.Entity<CONTA_ORC>()
                .Property(e => e.DEBCRE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONTA_ORC>()
                .Property(e => e.IDGRUCTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTA_ORC_GRU>()
                .Property(e => e.IDGRUCTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTA_ORC_GRU>()
                .Property(e => e.NOMGRUCTA)
                .IsUnicode(false);

            modelBuilder.Entity<CONTA_ORC_GRU>()
                .Property(e => e.NUMGRUCTA)
                .HasPrecision(3, 0);

            modelBuilder.Entity<CONTADOR>()
                .Property(e => e.IDCONT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTADOR>()
                .Property(e => e.CONTADOR1)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASORC>()
                .Property(e => e.CENTROCUSTO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASORC>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASORC>()
                .Property(e => e.CODIGOEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASORC>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASORC>()
                .Property(e => e.PERCENTUAL)
                .HasPrecision(6, 2);

            modelBuilder.Entity<CONTASORC>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATO_FIXO>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATO_FIXO>()
                .Property(e => e.DIA)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATO_FIXO>()
                .Property(e => e.IDLAN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO>()
                .Property(e => e.SITUACAO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATO_FIXO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.IDLANCONTFIX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.IDLAN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTRATO_FIXO_DET>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EPCMSO>()
                .Property(e => e.IDEPCMSO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EPCMSO>()
                .Property(e => e.ELABORADORPCMSO)
                .IsUnicode(false);

            modelBuilder.Entity<EPPRA>()
                .Property(e => e.IDEPPRA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EPPRA>()
                .Property(e => e.ELABORADORPPRA)
                .IsUnicode(false);

            modelBuilder.Entity<FATURAMENTO>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FATURAMENTO>()
                .Property(e => e.MES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FATURAMENTO>()
                .Property(e => e.ANO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FATURAMENTO>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<FATURAMENTO>()
                .Property(e => e.DIA)
                .IsUnicode(false);

            modelBuilder.Entity<FECHAMENTO_CAIXA>()
                .Property(e => e.IDFCX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FECHAMENTO_CAIXA>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<FECHAMENTO_CAIXA>()
                .Property(e => e.OBSERVACOES)
                .IsUnicode(false);

            modelBuilder.Entity<FECHAMENTO_CAIXA>()
                .Property(e => e.PERIODO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FECHAMENTO_CAIXA>()
                .Property(e => e.QUANTIDADE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORMADEPAGAMENTO>()
                .Property(e => e.IDFORPAG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORMADEPAGAMENTO>()
                .Property(e => e.FORMADEPAGAMENTO1)
                .IsUnicode(false);

            modelBuilder.Entity<FORMADEPAGAMENTO>()
                .Property(e => e.TIPOPAGTO)
                .IsUnicode(false);

            modelBuilder.Entity<FORMADEPAGAMENTO>()
                .HasMany(e => e.MOVIMENTO)
                .WithRequired(e => e.FORMADEPAGAMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.CTABANCO)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.CTAAGENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.CTACORRENTE)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.CNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.TIPOCONTA)
                .IsFixedLength();

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR>()
                .HasMany(e => e.FORNECEDOR_CONTATO)
                .WithRequired(e => e.FORNECEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FORNECEDOR>()
                .HasMany(e => e.FORNECEDORXPROCEDIMENTO)
                .WithRequired(e => e.FORNECEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FORNECEDOR>()
                .HasMany(e => e.TABELAXFORNECEDORXPROCEDIMENTO)
                .WithRequired(e => e.FORNECEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.IDCON)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.DEPARTAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.FONEFIXO)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.FONEMOVEL)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.FUNCAO)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.OBS)
                .IsUnicode(false);

            modelBuilder.Entity<FORNECEDOR_CONTATO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORNECEDORXPROCEDIMENTO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORNECEDORXPROCEDIMENTO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FORNECEDORXPROCEDIMENTO>()
                .HasMany(e => e.TABELAXFORNECEDORXPROCEDIMENTO)
                .WithRequired(e => e.FORNECEDORXPROCEDIMENTO)
                .HasForeignKey(e => new { e.IDFOR, e.IDPRO })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.IDFUN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.FUNCIONARIO1)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.CTPS)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.MATRICULA)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.CODNEXO)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .Property(e => e.TELEFONE)
                .IsUnicode(false);

            modelBuilder.Entity<FUNCIONARIO>()
                .HasMany(e => e.MOVIMENTO)
                .WithRequired(e => e.FUNCIONARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HISCONFIRMACAO>()
                .Property(e => e.IDHISCONF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HISCONFIRMACAO>()
                .Property(e => e.USUARIOREALIZADO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAUD>()
                .Property(e => e.IDLAUDO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDOAUD>()
                .Property(e => e.IDMOVPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDOAUD>()
                .Property(e => e.OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.IDLAUDO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.CORRECAO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.ESTRABISMO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.VISAOCROMATICA)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.OD)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.OE)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.IDFUN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.IDCGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.CONCLUSAO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.COD)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDOAV>()
                .Property(e => e.COE)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.MEDICO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.PACIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.IDADE)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.LAUDO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.CONCLUSAO)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.RODAPE)
                .IsUnicode(false);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.IDMODELO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.IDMOVPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LAUDORX>()
                .Property(e => e.LAUDONEGRITO)
                .IsUnicode(false);

            modelBuilder.Entity<LOGS>()
                .Property(e => e.IDLOG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LOGS>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<LOGS>()
                .Property(e => e.OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<MODELOLAUDO>()
                .Property(e => e.IDMODELO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MODELOLAUDO>()
                .Property(e => e.MODELO)
                .IsUnicode(false);

            modelBuilder.Entity<MODELOLAUDO>()
                .Property(e => e.LAUDO)
                .IsUnicode(false);

            modelBuilder.Entity<MODELOLAUDO>()
                .Property(e => e.CONCLUSAO)
                .IsUnicode(false);

            modelBuilder.Entity<MODELOLAUDO>()
                .Property(e => e.RODAPE)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDFUN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDCGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDREF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDFORPAG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO>()
                .Property(e => e.IDSETOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO>()
                .HasMany(e => e.MOVIMENTO_ARQUIVOS)
                .WithRequired(e => e.MOVIMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVIMENTO_ARQUIVOS>()
                .Property(e => e.IDARQUIVO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_ARQUIVOS>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_FECHAMENTO>()
                .Property(e => e.IDFEC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_FECHAMENTO>()
                .Property(e => e.DIA)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_FECHAMENTO>()
                .Property(e => e.PERIODO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_FECHAMENTO>()
                .HasMany(e => e.CLIENTE_CREDIARIO)
                .WithRequired(e => e.MOVIMENTO_FECHAMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDPRF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.OBSMOVTO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDMOVPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.USUARIOREALIZADO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDFCX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .Property(e => e.OBSREALIZADO)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .HasMany(e => e.LAUDOAUD)
                .WithRequired(e => e.MOVIMENTO_PROCEDIMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVIMENTO_PROCEDIMENTO>()
                .HasOptional(e => e.LAUDORX)
                .WithRequired(e => e.MOVIMENTO_PROCEDIMENTO);

            modelBuilder.Entity<MOVIMENTO_REFERENTE>()
                .Property(e => e.IDREF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOVIMENTO_REFERENTE>()
                .Property(e => e.NOMEREFERENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<NATUREZA>()
                .Property(e => e.IDNAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NATUREZA>()
                .Property(e => e.NATUREZA1)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDNF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.NUMNF)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.INSCESTADUAL)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.INSCMUNICIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IMPRIME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDCLIGRU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDBBCOBRANCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.OBSNF)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.ENTREGA)
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.NF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDFORPAG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NOTAFISCAL>()
                .Property(e => e.IDCID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PARAMETRO>()
                .Property(e => e.IDPAR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PARAMETRO>()
                .Property(e => e.SENHATRANSFERIRMOV)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMETRO>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PARAMETRO_TAB>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.CGC)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.CNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.CODIGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.HISTORICO)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.INS_ESTADUAL)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.INS_MUNICIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.INSTRUCOES)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.TELEFONE1)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.TELEFONE2)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .Property(e => e.TIPOPESSOA)
                .IsUnicode(false);

            modelBuilder.Entity<PASTASMOV>()
                .HasMany(e => e.LCTOSCAIXA)
                .WithRequired(e => e.PASTASMOV)
                .HasForeignKey(e => e.CODIGOPASTAMOV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PASTASMOV>()
                .HasMany(e => e.LCTOSCAIXA1)
                .WithRequired(e => e.PASTASMOV1)
                .HasForeignKey(e => e.CODIGOPASTAMOV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.PROCEDIMENTO1)
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.ABREVIADO)
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.CODNEXO)
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.IDSUBGRUPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDIMENTO>()
                .Property(e => e.IDPRF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .HasMany(e => e.FORNECEDORXPROCEDIMENTO)
                .WithRequired(e => e.PROCEDIMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROCEDIMENTO>()
                .HasMany(e => e.TABELAXFORNECEDORXPROCEDIMENTO)
                .WithRequired(e => e.PROCEDIMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROCEDIMENTO_GRUPO>()
                .Property(e => e.IDGRUPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDIMENTO_GRUPO>()
                .Property(e => e.GRUPOPROCEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO_GRUPO_SUBGRUP>()
                .Property(e => e.IDSUBGRUPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDIMENTO_GRUPO_SUBGRUP>()
                .Property(e => e.SUBGRUPO)
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDIMENTO_GRUPO_SUBGRUP>()
                .Property(e => e.IDGRUPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDIMENTO_GRUPO_SUBGRUP>()
                .HasMany(e => e.PROCEDIMENTO)
                .WithRequired(e => e.PROCEDIMENTO_GRUPO_SUBGRUP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROFISSIONAIS>()
                .Property(e => e.PROFISSIONAL)
                .IsUnicode(false);

            modelBuilder.Entity<PROFISSIONAIS>()
                .Property(e => e.IDPRF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROFISSIONAIS>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RECOMENDACAO>()
                .Property(e => e.IDREC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAO>()
                .Property(e => e.IDCGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAO>()
                .Property(e => e.IDSETOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXASO>()
                .Property(e => e.IDRECASO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXASO>()
                .Property(e => e.IDREC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXASO>()
                .Property(e => e.IDREF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXASOXPRO>()
                .Property(e => e.IDRECPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXASOXPRO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXASOXPRO>()
                .Property(e => e.IDRECASO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXRISCO>()
                .Property(e => e.IDRECXRISCO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXRISCO>()
                .Property(e => e.IDREC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RECOMENDACAOXRISCO>()
                .Property(e => e.IDRISCO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RISCO>()
                .Property(e => e.IDRISCO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RISCO>()
                .Property(e => e.RISCO1)
                .IsUnicode(false);

            modelBuilder.Entity<RISCO>()
                .Property(e => e.EVENTUALIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<RISCO>()
                .Property(e => e.IDNAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ROTA>()
                .Property(e => e.IDROTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ROTA>()
                .Property(e => e.NOMEROTA)
                .IsUnicode(false);

            modelBuilder.Entity<ROTA>()
                .Property(e => e.OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<SEGMENTO>()
                .Property(e => e.IDSEG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SEGMENTO>()
                .Property(e => e.SEGMENTO1)
                .IsUnicode(false);

            modelBuilder.Entity<SETOR>()
                .Property(e => e.IDSETOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SETOR>()
                .Property(e => e.SETOR1)
                .IsUnicode(false);

            modelBuilder.Entity<SETOR>()
                .HasMany(e => e.MOVIMENTO)
                .WithRequired(e => e.SETOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SETOR>()
                .HasMany(e => e.RECOMENDACAO)
                .WithRequired(e => e.SETOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_CAIXA>()
                .Property(e => e.CODCAI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CAIXA>()
                .Property(e => e.CODCAI_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CAIXA>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CAIXA>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CAIXA>()
                .HasMany(e => e.SYS_MAIL)
                .WithRequired(e => e.SYS_CAIXA)
                .HasForeignKey(e => new { e.CODCAI, e.CODUSU });

            modelBuilder.Entity<SYS_CATEND>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CATEND>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CATEND>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CLASSES>()
                .Property(e => e.CLASSE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CLASSES>()
                .Property(e => e.PUBLICADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CLASSES>()
                .Property(e => e.COMPILADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CLASSES>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_COMSQL>()
                .Property(e => e.CODCOMANDOSQL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_COMSQL>()
                .Property(e => e.CONSULTA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_COMSQL>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CONCORRENCIA>()
                .Property(e => e.CODCONC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CONCORRENCIA>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CONCORRENCIA>()
                .Property(e => e.CHAVEREG)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CONSULTA>()
                .Property(e => e.CODCONSULTA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CONSULTA>()
                .Property(e => e.CODPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_CONSULTA>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CONSULTA>()
                .Property(e => e.TIPODIAGR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_FICHATECNICA>()
                .Property(e => e.CODCATEGORIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_FICHATECNICA>()
                .Property(e => e.NOMECATEGORIA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_FICHATECNICA>()
                .Property(e => e.NOMETELA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_FICHATECNICA>()
                .Property(e => e.NOMETABELA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_FICHATECNICA>()
                .HasMany(e => e.SYS_USRCOMPONENT)
                .WithMany(e => e.SYS_FICHATECNICA)
                .Map(m => m.ToTable("SYS_FICHAXCOMPONENTE").MapLeftKey("CODCATEGORIA").MapRightKey("CODCOMPONENTE"));

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.CODHELP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.ALTERADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.CONTEXTO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.PALAVRAS_CHAVE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.TOPICO_IDX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_HELP>()
                .Property(e => e.TOPICO_PAI)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELP>()
                .HasOptional(e => e.SYS_HELPBODY)
                .WithRequired(e => e.SYS_HELP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CODHELP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CONTEUDOHTML_ENG)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CONTEUDOHTML_ESP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CONTEUDOHTML_PTB)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CONTEUDOTXT_ENG)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CONTEUDOTXT_ESP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_HELPBODY>()
                .Property(e => e.CONTEUDOTXT_PTB)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.CODKPI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.NOMEFORM)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.USAFILTRO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.PARAMETROS)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_KPI>()
                .Property(e => e.CODREL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.COD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.DIRPADRAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.IDUNICO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.LAYOUT)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.FILTRO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.IMPEXP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LAYOUT>()
                .Property(e => e.EXTENSAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.CODMSG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.MENSAGEM)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.CODUSU_REMETENTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.CODUSU_DESTINATARIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.BOTAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.RESPOSTA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LOGMSG>()
                .Property(e => e.ENTREGUE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LTELA>()
                .Property(e => e.CODLTELA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LTELA>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_LTELA>()
                .Property(e => e.NOMECOMPONENTE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LTELA>()
                .Property(e => e.NOMEFORM)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_LTELA>()
                .Property(e => e.CATEGORIA_FT)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.CODMAI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.ASSUNTO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.CODCAI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.DESTCC)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.DESTPARA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.EMAILLIDO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.MESSAGEID)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.REMETENTE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_MAIL>()
                .Property(e => e.TEMANEXOS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REFRULES>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REFRULES>()
                .Property(e => e.VERSAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.CONTEUDO_BLN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.CONTEUDO_STR)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.CONTEUDO_TXT)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.TOPICO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGINI>()
                .Property(e => e.VARIAVEL)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.ASSINATURA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.COMPILADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.EVENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.EXECUCAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.FORM)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.OBJETO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.PUBLICADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.SOURCE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.TIPEVENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REGRAS>()
                .Property(e => e.TIPOBJETO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.CODREL)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.ID_DEV)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.COMANDOSQL)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.FILTROEXTERNO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.HELP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.ESTRUTURA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .Property(e => e.EDITAVEL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_REPORTS>()
                .HasMany(e => e.SYS_KPI)
                .WithOptional(e => e.SYS_REPORTS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.CODUSRCOLUMN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.CHAVE_PK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.CODUSRTABLE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.OBRIGATORIO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .Property(e => e.VALOR_PADRAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOLUMN>()
                .HasMany(e => e.SYS_USUARIO)
                .WithMany(e => e.SYS_USRCOLUMN)
                .Map(m => m.ToTable("SYS_USRCOLUMNXSYS_USUARIO").MapLeftKey("CODUSRCOLUMN").MapRightKey("CODUSU"));

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.CODCOMPONENT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.CODFORM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.CODUSRCOLUMN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.CONFCOMPONENT)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.DATAOBJECT)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.PARENT)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRCOMPONENT>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRFORM>()
                .Property(e => e.CODFORM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRFORM>()
                .Property(e => e.CODUSRTABLE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRFORM>()
                .Property(e => e.FORMPADRAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRFORM>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRFORM>()
                .Property(e => e.TIPOFORM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRFORM>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRFORMXTABLE>()
                .Property(e => e.CODFORM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRFORMXTABLE>()
                .Property(e => e.CODTABLE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRFORMXTABLE>()
                .Property(e => e.TIPOFORM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRON>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRON>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRON>()
                .Property(e => e.VERSAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRTABLE>()
                .Property(e => e.CODUSRTABLE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRTABLE>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRTABLE>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRTABLE>()
                .HasMany(e => e.SYS_USRFORMXTABLE)
                .WithRequired(e => e.SYS_USRTABLE)
                .HasForeignKey(e => e.CODTABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.SENHA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.MENUEDITADO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.TOOLBAREDITADO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.PROLAYOUT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.LOGINWIN)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.CODUSU_GRU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.REMETENTE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.NOMEEXIB)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.AUTENTICACAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.LOGINMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.SENHAMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.SMTP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.POP)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.PORTASMTP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.PORTAPOP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.CONEXSEGURA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.DEIXARCOPIAMSG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.MARCARLIDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.EXPSENHA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.TROCARSENHA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.TROCARSENHAEXP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.TODOSRELATORIOS)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.CFGMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.ASSINATURA)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.ENTERTOTAB)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.UPDATERULES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.TIMEROC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.GRAVARALTERACOES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.GRAVARNAVEGACAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.GRAVARPERSONALIZACOES)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.BLOQUEARSESSAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .Property(e => e.RELATSIMULTANEO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .HasMany(e => e.SYS_LOGMSG)
                .WithRequired(e => e.SYS_USUARIO)
                .HasForeignKey(e => e.CODUSU_DESTINATARIO);

            modelBuilder.Entity<SYS_USUARIO>()
                .HasMany(e => e.SYS_LOGMSG1)
                .WithRequired(e => e.SYS_USUARIO1)
                .HasForeignKey(e => e.CODUSU_REMETENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_USUARIO>()
                .HasMany(e => e.SYS_LTELA)
                .WithOptional(e => e.SYS_USUARIO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SYS_USUARIO>()
                .HasOptional(e => e.SYS_USRXREL)
                .WithRequired(e => e.SYS_USUARIO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SYS_USUARIO>()
                .HasMany(e => e.SYS_USUARIO1)
                .WithOptional(e => e.SYS_USUARIO2)
                .HasForeignKey(e => e.CODUSU_GRU);

            modelBuilder.Entity<TAB>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TAB>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TAB>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TABELA>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TABELA>()
                .Property(e => e.TABELA1)
                .IsUnicode(false);

            modelBuilder.Entity<TABELA>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABELA>()
                .Property(e => e.TIPOPAGTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TABELA>()
                .HasMany(e => e.CLIENTE_CREDIARIO)
                .WithRequired(e => e.TABELA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TABELA>()
                .HasMany(e => e.MOVIMENTO)
                .WithRequired(e => e.TABELA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TABELA>()
                .HasMany(e => e.TABELAXFORNECEDORXPROCEDIMENTO)
                .WithRequired(e => e.TABELA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TABELAXFORNECEDORXPROCEDIMENTO>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TABELAXFORNECEDORXPROCEDIMENTO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TABELAXFORNECEDORXPROCEDIMENTO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TABELAXFORNECEDORXPROCEDIMENTO>()
                .HasOptional(e => e.TAB)
                .WithRequired(e => e.TABELAXFORNECEDORXPROCEDIMENTO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TABELAXFORNECEDORXPROCEDIMENTO>()
                .HasMany(e => e.CLIENTE_CONTRATOFIXO)
                .WithOptional(e => e.TABELAXFORNECEDORXPROCEDIMENTO)
                .HasForeignKey(e => new { e.IDTAB, e.IDFOR, e.IDPRO });

            modelBuilder.Entity<AUDIOMETRIA>()
                .Property(e => e.AUDIOMETRO)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.AGENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.CONTATO)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.TELEFONE)
                .IsUnicode(false);

            modelBuilder.Entity<BANCOS>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTRATOFIXO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_CONTRATOFIXO>()
                .Property(e => e.IDCRE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CONTRATOFIXO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CONTRATOFIXO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CONTRATOFIXO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_CONTRATOFIXO>()
                .Property(e => e.IDTAB)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.PCMSO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.CODNEXO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.NAODESEJA)
                .HasPrecision(1, 0);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.IDEPCMSO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CLIENTE_OCUPACIONAL>()
                .Property(e => e.IDEPPRA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONTASBANCARIAS>()
                .Property(e => e.GERENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASBANCARIAS>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASBANCARIAS>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.AGENCIABANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.CGC_CPF)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.CODIGOCONTAORC)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.DOCUMENTOBAIXA)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.HISTORICO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.NOMEBANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.NOMEEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.NROBANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.NROCHEQUEEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.NROCONTAEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASPAGAR>()
                .Property(e => e.ORIGEM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.AGENCIABANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.CGC_CPF)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.CODIGOCONTAORC)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.DOCUMENTOBAIXA)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.HISTORICO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.NOMEBANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.NOMEEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.NOSSONUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.NROBANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.NROCHEQUEEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.NROCONTAEMI)
                .IsUnicode(false);

            modelBuilder.Entity<CONTASRECEBER>()
                .Property(e => e.ORIGEM)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATOSFORNEC>()
                .Property(e => e.ANOTACOES)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATOSFORNEC>()
                .Property(e => e.ATIVO)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATOSFORNEC>()
                .Property(e => e.CTAORC_ID)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATOSFORNEC>()
                .Property(e => e.HISTORICOBASE)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRATOSFORNEC>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.CODIGOCENTROCUSTO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.CODIGOCOMPCX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.CODIGOCONTAORC)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.CODIGOPASTAMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.CONTROLE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.HISTORICO)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.OPERACAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCAIXA>()
                .Property(e => e.ORIGEM)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.AGENCIABANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.CGC_CPF_EMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.CODIGOCONTAORC)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.CODIGOCONTAORCDEST)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.DOCUMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.EFETUADO)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.HISTORICO)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.NOMEBANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.NOMEEMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.NROBANCOEMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.NROCHEQUE)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.NROCHEQUEEMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.NROCONTAEMI)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.OPERACAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.ORIGEM)
                .IsUnicode(false);

            modelBuilder.Entity<LCTOSCONTAS>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CFGGER>()
                .Property(e => e.LOCKDBNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CFGGER>()
                .Property(e => e.LOCKDBACTION)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CFGGER>()
                .Property(e => e.VERSAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_CFGGER>()
                .Property(e => e.ULTIMOACESSO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRLOG>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SYS_USRLOG>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USRXREL>()
                .Property(e => e.CODUSU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TEXTOPADRAO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<TEXTOPADRAO>()
                .Property(e => e.TEXTO)
                .IsUnicode(false);

            modelBuilder.Entity<TEXTOPADRAO>()
                .Property(e => e.TIPO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TIPOSCONTRATOS>()
                .Property(e => e.DESCTIPCONT)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOSCONTRATOS>()
                .Property(e => e.TITULOTIPCONT)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOSDOCTOS>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOSDOCTOS>()
                .Property(e => e.NOTAS)
                .IsUnicode(false);

            modelBuilder.Entity<CONT_MOV_CLI>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.NUMCONTROLE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.TIPOCLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.DATAEMISSAO)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.CODIGOCIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.DESCSERVPREST)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.LC116)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.ITEMLC)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.VALORSERVICO)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.QTDSOMA)
                .HasPrecision(38, 0);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.TOTALNOTA)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.ALIQUOTA)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.ISS)
                .IsUnicode(false);

            modelBuilder.Entity<EXPORTACAO_NF>()
                .Property(e => e.MUNICIPIO)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.IDMov)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Funcionário)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Fornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Procedimento)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.IDMovPro)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Observacao_Procedimento)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Usuário)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Profissional)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Usuario_Realizado)
                .IsUnicode(false);

            modelBuilder.Entity<MOV_PROC_COMPLETO>()
                .Property(e => e.Faturamento)
                .HasPrecision(18, 0);

            modelBuilder.Entity<QUANTIDADE_NOTAFISCAL>()
                .Property(e => e.IDNF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<QUANTIDADE_NOTAFISCAL>()
                .Property(e => e.QTDSOMA)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SELECTANUAL>()
                .Property(e => e.PROCEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTANUAL>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTANUAL>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTANUAL>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTANUAL>()
                .Property(e => e.PROXIMOANO)
                .IsUnicode(false);

            modelBuilder.Entity<selectultimomovcli>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<selectultimomovcli>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<selectultimomovcli>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<selectultimomovcli>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTULTIMOMOVCLIENTE>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SELECTULTIMOMOVCLIENTE>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTULTIMOMOVCLIENTE>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SELECTULTIMOMOVCLIENTE>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_ACOMPANHAMENTO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_ACOMPANHAMENTO>()
                .Property(e => e.MINIMO)
                .HasPrecision(38, 2);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDREC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDSETOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.SETOR)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDCGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDRECASO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDREF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.NOMEREFERENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDRECPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.PROCEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.ABREVIADO)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDFOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.NFFOR)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.RSFOR)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDPRF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.PROFISSIONAL)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDSUBGRUPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.SUBGRUPO)
                .IsUnicode(false);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.IDGRUPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SL_RECOMENDACAO>()
                .Property(e => e.GRUPOPROCEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.IDMOVPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.IDFUN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.FUNCIONARIO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.NOMECLI)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.RAZAOCLI)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.NOMEREFERENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.DATA)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.DATAMOV)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.DATAEXAME)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.TABELA)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.TIPOPAGTO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.IDFCX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.SUBGRUPO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.DATAREALIZADO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.USUARIOREALIZADO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.PROCEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.PROFISSIONAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.CONFIRMADO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.FATURADO)
                .IsUnicode(false);

            modelBuilder.Entity<SLCONSULTAMOVIMENTO>()
                .Property(e => e.CAIXAPENDENTE)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDREC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.NOMEFANTASIA)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDCGO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDREF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.NOMEREFERENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDPROREC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.REALIZADO)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDPRO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.PROCEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDMOV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.IDFUN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.FUNCIONARIO)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<slmovxrec>()
                .Property(e => e.CONFIRMADO)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.IDNF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.NUMNF)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.INSCESTADUAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.IDFORPAG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.IDCID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.NF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.INSCMUNICIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.OBSNF)
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.IMPRIME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SLNFCL>()
                .Property(e => e.ENTREGA)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.QUANTIDADE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.IDNF)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.SUBGRUPO)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.NUMNF)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.RAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.INSCESTADUAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.INSCMUNICIPAL)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.CPFCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.IDFAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.IMPRIME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.IDCLIGRU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.IDCLI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.OBSNF)
                .IsUnicode(false);

            modelBuilder.Entity<SLNOTAFISCAL>()
                .Property(e => e.NF)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
