using MP09.UF01.P01.VisitaMedica.model.domain;

namespace MP09.UF01.P01.Seguretat.model.domain
{
    public class UsuariController
    {
        VisitaMedicaView visitaMedicaView = new VisitaMedicaView();

        public void AplicaSeguretatMD5()
        {
            try
            {
                visitaMedicaView.ShowMissatge("MD5 ------------", false);
                VisitaMedica visitaMedica = visitaMedicaView.GetVisitaMedica();
                MD5Security security = new MD5Security();
                string nomPacientEnc = security.Encripta(visitaMedica.NomPacient);
                string diagnosiEnc = security.Encripta(visitaMedica.Diagnosi);

                VisitaMedica visitaMedicaEnc = new VisitaMedica();
                visitaMedicaEnc.NomPacient = nomPacientEnc;
                visitaMedicaEnc.Diagnosi = diagnosiEnc;

                visitaMedicaView.ShowVisitaMedica(visitaMedicaEnc);
            }
            catch (Exception ex)
            {
                visitaMedicaView.ShowMissatge(ex.Message, true);
            }
        }

        public void AplicaSeguretatSHA256()
        {
            try
            {
                visitaMedicaView.ShowMissatge("SHA256 ------------", false);
                VisitaMedica visitaMedica = visitaMedicaView.GetVisitaMedica();
                SHA256Security security = new SHA256Security();
                string mailEnc = security.Encripta(visitaMedica.Mail);
                string passwordEnc = security.Encripta(visitaMedica.Password);

                VisitaMedica visitaMedicaEnc = new VisitaMedica();
                visitaMedicaEnc.Mail = mailEnc;
                visitaMedicaEnc.Password = passwordEnc;

                visitaMedicaView.ShowVisitaMedica(visitaMedicaEnc);
            }
            catch (Exception ex)
            {
                visitaMedicaView.ShowMissatge(ex.Message, true);
            }
        }

        public void AplicaSeguretatAES()
        {
            try
            {
                visitaMedicaView.ShowMissatge("AES ------------ Encripta", false);
                VisitaMedica visitaMedica = visitaMedicaView.GetVisitaMedica();
                AESSecurity security = new AESSecurity();
                string mailEnc = security.Encripta(visitaMedica.Mail);
                string passwordEnc = security.Encripta(visitaMedica.Password);

                VisitaMedica visitaMedicaEnc = new VisitaMedica();
                visitaMedicaEnc.Mail = mailEnc;
                visitaMedicaEnc.Password = passwordEnc;

                visitaMedicaView.ShowVisitaMedica(visitaMedicaEnc);

                visitaMedicaView.ShowMissatge("AES ------------ Desencripta", false);

                string mailDesenc = security.Desencripta(visitaMedicaEnc.Mail);
                string passwordDesenc = security.Desencripta(visitaMedicaEnc.Password);

                VisitaMedica visitaMedicaDesenc = new VisitaMedica();
                visitaMedicaDesenc.Mail = mailDesenc;
                visitaMedicaDesenc.Password = passwordDesenc;
                visitaMedicaView.ShowVisitaMedica(visitaMedicaDesenc);
            }
            catch (Exception ex)
            {
                visitaMedicaView.ShowMissatge(ex.Message, true);
            }
        }
    }
}

