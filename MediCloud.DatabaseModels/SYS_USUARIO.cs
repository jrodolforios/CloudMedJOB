namespace MediCloud.DatabaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SYS_USUARIO
    {
        #region Public Constructors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_USUARIO()
        {
            SYS_CAIXA = new HashSet<SYS_CAIXA>();
            SYS_CATEND = new HashSet<SYS_CATEND>();
            SYS_CONCORRENCIA = new HashSet<SYS_CONCORRENCIA>();
            SYS_LOGMSG = new HashSet<SYS_LOGMSG>();
            SYS_LOGMSG1 = new HashSet<SYS_LOGMSG>();
            SYS_LTELA = new HashSet<SYS_LTELA>();
            SYS_USRON = new HashSet<SYS_USRON>();
            SYS_USRLOG = new HashSet<SYS_USRLOG>();
            SYS_USUARIO1 = new HashSet<SYS_USUARIO>();
            SYS_USRCOLUMN = new HashSet<SYS_USRCOLUMN>();
        }

        #endregion Public Constructors



        #region Public Properties

        [Column(TypeName = "text")]
        public string ASSINATURA { get; set; }

        [StringLength(1)]
        public string AUTENTICACAO { get; set; }

        [StringLength(1)]
        public string BLOQUEARSESSAO { get; set; }

        [StringLength(15)]
        public string CFGMAIL { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CODUSU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CODUSU_GRU { get; set; }

        [StringLength(1)]
        public string CONEXSEGURA { get; set; }

        [Column(TypeName = "image")]
        public byte[] CTRLACESSO { get; set; }

        public DateTime? DATALT { get; set; }

        public DateTime? DATALTSENHA { get; set; }

        [StringLength(1)]
        public string DEIXARCOPIAMSG { get; set; }

        [StringLength(15)]
        public string ENTERTOTAB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EXPSENHA { get; set; }

        [StringLength(1)]
        public string GRAVARALTERACOES { get; set; }

        [StringLength(1)]
        public string GRAVARNAVEGACAO { get; set; }

        [StringLength(1)]
        public string GRAVARPERSONALIZACOES { get; set; }

        [Required]
        [StringLength(50)]
        public string LOGIN { get; set; }

        [StringLength(100)]
        public string LOGINMAIL { get; set; }

        [StringLength(50)]
        public string LOGINWIN { get; set; }

        [StringLength(1)]
        public string MARCARLIDA { get; set; }

        [Column(TypeName = "text")]
        public string MENUEDITADO { get; set; }

        [Required]
        [StringLength(250)]
        public string NOME { get; set; }

        [StringLength(100)]
        public string NOMEEXIB { get; set; }

        [StringLength(100)]
        public string POP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PORTAPOP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PORTASMTP { get; set; }

        [StringLength(1)]
        public string PROLAYOUT { get; set; }

        [Required]
        [StringLength(1)]
        public string RELATSIMULTANEO { get; set; }

        [StringLength(100)]
        public string REMETENTE { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string SENHA { get; set; }

        [StringLength(100)]
        public string SENHAMAIL { get; set; }

        [StringLength(100)]
        public string SMTP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_CAIXA> SYS_CAIXA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_CATEND> SYS_CATEND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_CONCORRENCIA> SYS_CONCORRENCIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_LOGMSG> SYS_LOGMSG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_LOGMSG> SYS_LOGMSG1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_LTELA> SYS_LTELA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRCOLUMN> SYS_USRCOLUMN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRLOG> SYS_USRLOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USRON> SYS_USRON { get; set; }

        public virtual SYS_USRXREL SYS_USRXREL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USUARIO> SYS_USUARIO1 { get; set; }

        public virtual SYS_USUARIO SYS_USUARIO2 { get; set; }

        [StringLength(1)]
        public string TIMEROC { get; set; }

        [StringLength(1)]
        public string TIPO { get; set; }

        [StringLength(15)]
        public string TODOSRELATORIOS { get; set; }

        [Column(TypeName = "text")]
        public string TOOLBAREDITADO { get; set; }

        [StringLength(1)]
        public string TROCARSENHA { get; set; }

        [StringLength(1)]
        public string TROCARSENHAEXP { get; set; }

        [StringLength(1)]
        public string UPDATERULES { get; set; }

        #endregion Public Properties
    }
}