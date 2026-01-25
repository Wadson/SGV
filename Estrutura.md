
👉 Esse diagrama mostra:
- O projeto principal **SGVendas** com suas pastas MVC (Controllers, Views, Models).
- Cada pasta com classes típicas.
- Os projetos auxiliares (**Domain, Data, Services**) com suas classes.

---

## 🔧 3. Automatizando (se quiser evitar escrever manualmente)
- Você pode usar ferramentas como **dotnet-project-graph** ou **NDepend** para gerar gráficos automáticos da solução.
- Outra opção é rodar um script PowerShell para listar todos os arquivos e pastas em formato hierárquico.

Exemplo PowerShell (executado na raiz da solução):
```powershell
tree /f > estrutura.txt
