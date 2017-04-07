using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System.Data.Entity.Validation;
using MediCloud.BusinessProcess.Util;

namespace MediCloud.BusinessProcess.Cliente
{
    public class ControleDeASO
    {
        public static List<MOVIMENTO> buscarCliente(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.MOVIMENTO.ToList();
                }
                else
                {
                    return contexto.MOVIMENTO.Where(x => x.CLIENTE.NOMEFANTASIA.Contains(termo)
                        || x.FUNCIONARIO.FUNCIONARIO1.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<MOVIMENTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MOVIMENTO buscarASOPorId(int idASO)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (idASO <= 0)
                {
                    return null;
                }
                else
                {
                    return contexto.MOVIMENTO.First(x => x.IDMOV == idASO);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new MOVIMENTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MOVIMENTO SalvarASO(MOVIMENTO ASODAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            MOVIMENTO usuarioSalvo = new MOVIMENTO();

            try
            {

                if (ASODAO.IDMOV > 0)
                {
                    usuarioSalvo = contexto.MOVIMENTO.First(x => x.IDMOV == ASODAO.IDMOV);

                    usuarioSalvo.CAIXAPENDENTE = ASODAO.CAIXAPENDENTE;
                    usuarioSalvo.DATA = ASODAO.DATA;
                    usuarioSalvo.DATAMOV = ASODAO.DATAMOV;
                    usuarioSalvo.FATURA = ASODAO.FATURA;
                    usuarioSalvo.IDCGO = ASODAO.IDCGO;
                    usuarioSalvo.IDCLI = ASODAO.IDCLI;
                    usuarioSalvo.IDFAT = ASODAO.IDFAT;
                    usuarioSalvo.IDFCX = ASODAO.IDFCX;
                    usuarioSalvo.IDFORPAG = ASODAO.IDFORPAG;
                    usuarioSalvo.IDFUN = ASODAO.IDFUN;
                    usuarioSalvo.IDMOV = ASODAO.IDMOV;
                    usuarioSalvo.IDREF = ASODAO.IDREF;
                    usuarioSalvo.IDSETOR = ASODAO.IDSETOR;
                    usuarioSalvo.IDTAB = ASODAO.IDTAB;
                    usuarioSalvo.OBSERVACAO = ASODAO.OBSERVACAO;
                    usuarioSalvo.STATUS = ASODAO.STATUS;
                    usuarioSalvo.TIPO = ASODAO.TIPO;
                    usuarioSalvo.USUARIO = ASODAO.USUARIO;   

                }
                else
                {
                    //ASOs novos tem seu caixa sempre pendente
                    ASODAO.CAIXAPENDENTE = true;

                    usuarioSalvo = contexto.MOVIMENTO.Add(ASODAO);
                }

                contexto.SaveChanges();
                return usuarioSalvo;

            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
