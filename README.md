## Dokumentacja procesu CI/CD

W projekcie skonfigurowano automatyzację za pomocą **GitHub Actions**:
1. **Trigger:** Proces (Workflow) uruchamia się automatycznie przy każdym `push` do gałęzi `main`.
2. **Środowisko:** Aplikacja jest budowana na systemie Linux (Ubuntu).
3. **Kroki:**
   - Pobranie kodu źródłowego.
   - Konfiguracja środowiska .NET 9.
   - Przywrócenie zależności (NuGet).
   - Budowanie projektu w trybie Release w celu weryfikacji poprawności kodu.
