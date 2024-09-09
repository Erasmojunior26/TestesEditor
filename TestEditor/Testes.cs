using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEditor;

namespace TestEditor
{
    public class Testes : Begin
    {
        [Test]
        public void TestCadastroValido()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/ul/a[2]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TextField16\"]")).SendKeys("Erasmo Nascimento");
            driver.FindElement(By.XPath("//*[@id=\"TextField18\"]")).SendKeys("erasmojuniordev@gmail.com"); // Caso teste novamente, é necessário trocar o email
            driver.FindElement(By.XPath("//*[@id=\"TextField20\"]")).SendKeys("boas2011");
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[2]/div/form/div[4]/div/div/label/div/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"id__26\"]")).Click();

            Assert.That(driver.FindElement(By.XPath("//*[@id=\"Dialog29-title\"]")).Text.Contains("Cadastro Realizado"), Is.True);
        }

        [Test]
        public void TestCadastroInvalido() // Utilizando campos vazios e textos em formatos inválidos para email para verificar o funcionamento do required
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/ul/a[2]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TextField16\"]")).SendKeys("");
            driver.FindElement(By.XPath("//*[@id=\"TextField18\"]")).SendKeys("erasmojunior");
            driver.FindElement(By.XPath("//*[@id=\"TextField20\"]")).SendKeys("");
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[2]/div/form/div[4]/div/div/label/div/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"id__26\"]")).Click();

            Assert.That(driver.FindElement(By.XPath("//*[@id=\"TextFieldDescription17\"]/div/p/span")).Text.Contains("Informe o nome completo"), Is.True);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"TextFieldDescription19\"]/div/p/span")).Text.Contains("E-mail inválido"), Is.True);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"TextFieldDescription21\"]/div/p/span")).Text.Contains("A senha deve conter no mínimo 6 e no máximo 20 caracteres"), Is.True);
        }

        [Test]
        public void TestEmailCadastrado()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/ul/a[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"TextField16\"]")).SendKeys("erasmojuniordev@gmail.com"); // Utilize um email cadastro para acessar
            driver.FindElement(By.XPath("//*[@id=\"TextField18\"]")).SendKeys("boas2011");
            driver.FindElement(By.XPath("//*[@id=\"root\"]/div[2]/div[2]/div/form/div[3]/div/div/div/div/label/div/i")).Click();
            driver.FindElement(By.XPath("//*[@id=\"id__25\"]")).Click();

        }

        [Test]
        public void TestSalvarTarefa()
        {
            TestEmailCadastrado();

            driver.FindElement(By.XPath("//*[@id=\"input-task\"]")).SendKeys("Teste de Editor de Tarefas" + Keys.Enter); // Modifique a mensagem para visualizar melhor
        }

        [Test]
        public void TestNavegacaoMenu() // É necessário ter uma tarefa salva na conta utilizada
        {
            TestEmailCadastrado();

            driver.FindElement(By.XPath("//*[@id=\"TODAY\"]/div/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"WEEK\"]/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"MONTH\"]/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"STARRED\"]/div/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"RECURRENT\"]/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"PASTDUE\"]/div/div/div/div/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"ALL\"]/div/div/div/div/span")).Click();
        }

    }
}