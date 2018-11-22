using MediCloud.BusinessProcess.Util;
using MediCloud.DatabaseModels;
using MediCloud.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MediCloud.BusinessProcess.Cliente
{
    public class ControleDeCargo
    {
        #region Public Methods

        public static CARGO buscarCargoPorID(int codigoCargo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                CARGO funcionario = contexto.CARGO.First(x => x.IDCGO == codigoCargo);

                return funcionario;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static List<CARGO> buscarCargosPorTermo(string prefix)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                List<CARGO> cargo = contexto.CARGO.Where(x => x.CARGO1.Contains(prefix)).ToList();

                return cargo;
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static List<CARGO> buscarCliente(string termo)
        {
            CloudMedContext contexto = new CloudMedContext();

            try
            {
                if (string.IsNullOrEmpty(termo))
                {
                    return contexto.CARGO.ToList();
                }
                else
                {
                    return contexto.CARGO.Where(x => x.CARGO1.Contains(termo)
                        || x.ABREVIADO.Contains(termo)).ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
                return new List<CARGO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExcluirCargo(int codigoDoCargo)
        {
            CloudMedContext contexto = new CloudMedContext();
            try
            {
                contexto.CARGO.Remove(contexto.CARGO.First(x => x.IDCGO == codigoDoCargo));

                contexto.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ExceptionUtil.TratarErrosDeValidacaoDoBanco(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CARGO SalvarCargo(CARGO cargoDAO)
        {
            CloudMedContext contexto = new CloudMedContext();
            CARGO cargoSalvo = new CARGO();

            try
            {
                if (cargoDAO.IDCGO > 0)
                {
                    cargoSalvo = contexto.CARGO.First(x => x.IDCGO == cargoDAO.IDCGO);

                    cargoSalvo.ABREVIADO = cargoDAO.ABREVIADO;
                    cargoSalvo.CARGO1 = cargoDAO.CARGO1;
                    cargoSalvo.CODNEXO = cargoDAO.CODNEXO;
                    cargoSalvo.STATUS = cargoDAO.STATUS;
                }
                else
                {
                    ValidarCargo(contexto, cargoDAO);
                    cargoSalvo = contexto.CARGO.Add(cargoDAO);
                }

                contexto.SaveChanges();
                return cargoSalvo;
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

        #endregion Public Methods



        #region Private Methods

        private static void ValidarCargo(CloudMedContext contexto, CARGO cargoDAO)
        {
            if (contexto.CARGO.Any(x => x.CARGO1 == cargoDAO.CARGO1))
                throw new InvalidOperationException("Já existe um cargo no sistema com este mesmo nome.");
        }

        #endregion Private Methods
    }
}