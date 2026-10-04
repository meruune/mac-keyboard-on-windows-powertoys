using System.Windows.Forms;

namespace KeyMapper;

internal class Keymap
{
    // PowerToys will evaluate this BEFORE everything else
    // -> Alt and ctrl defs need to be swapped in the Keys enum
    public static Dictionary<Keys, Keys> KeysMap = new()
    {
        [Keys.Alt] = Keys.Control,
        [Keys.Control] = Keys.Alt
    };

    public static Dictionary<List<Keys>, List<Keys>> ShortcutsMap = new()
    {
        // Cut, copy, paste, and other common shortcuts
        [[Keys.LAlt, Keys.C]] = [Keys.LControlKey, Keys.C], // Command-C: Copy the selected item to the Clipboard.
        [[Keys.LAlt, Keys.V]] = [Keys.LControlKey, Keys.V], // Command-V: Paste the contents of the Clipboard into the current document or app.
        [[Keys.LAlt, Keys.X]] = [Keys.LControlKey, Keys.X], // Command-X: Cut the selected item and copy it to the Clipboard.
        [[Keys.LAlt, Keys.Z]] = [Keys.LControlKey, Keys.Z], // Command-Z: Undo the previous command.
        [[Keys.LAlt, Keys.LShiftKey, Keys.Z]] = [Keys.LControlKey, Keys.Y], // Shift-Command-Z to Redo, reversing the undo command.
        [[Keys.LAlt, Keys.A]] = [Keys.LControlKey, Keys.A], // Command-A: Select All items.
        [[Keys.LAlt, Keys.S]] = [Keys.LControlKey, Keys.S], // Command-S: Save the current document.
        [[Keys.LAlt, Keys.F]] = [Keys.LControlKey, Keys.F], // Command-F: Find items in a document or open a Find window.
        [[Keys.LAlt, Keys.G]] = [Keys.F3],                  // Command-G: Find Again: Find the next occurrence of the item previously found.
        [[Keys.LAlt, Keys.LShiftKey, Keys.G]] = [Keys.LShiftKey, Keys.F3], // Shift-Command-G: To find the previous occurrence.
        [[Keys.LAlt, Keys.O]] = [Keys.LControlKey, Keys.O], // Command-O: Open the selected item, or open a dialog to select a file to open.
        [[Keys.LAlt, Keys.P]] = [Keys.LControlKey, Keys.P], // Command-P: Print the current document.
        [[Keys.LAlt, Keys.T]] = [Keys.LControlKey, Keys.T], // Command-T: Open a new tab.
        [[Keys.LAlt, Keys.N]] = [Keys.LControlKey, Keys.N], // Command-N: Open a new Finder window (or New Document).
        [[Keys.LAlt, Keys.R]] = [Keys.LControlKey, Keys.R], // Command-R: In some apps, such as Calendar or Safari, refresh or reload the page.

        // Document formatting shortcuts
        [[Keys.LAlt, Keys.B]] = [Keys.LControlKey, Keys.B], // Command-B: Boldface the selected text, or turn boldfacing on or off.
        [[Keys.LAlt, Keys.I]] = [Keys.LControlKey, Keys.I], // Command-I: Italicize the selected text, or turn italics on or off.
        [[Keys.LAlt, Keys.U]] = [Keys.LControlKey, Keys.U], // Command-U: Underline the selected text, or turn underlining on or off.

        // Window ops
        [[Keys.LAlt, Keys.W]] = [Keys.LControlKey, Keys.W], // Command-W: Close the front window.
        [[Keys.LAlt, Keys.Q]] = [Keys.LAlt, Keys.F4],       // Command-Q: Quit app (Alt+F4 on Windows).

        // App switching
        [[Keys.LAlt, Keys.Tab]] = [Keys.Alt, Keys.Tab],               // Cmd+Tab  → Alt+Tab  (app switcher)
        [[Keys.LControlKey, Keys.Tab]] = [Keys.Control, Keys.Tab], // Ctrl+Tab → Ctrl+Tab (in-app tabs, prevent swap)

        // Screenshots
        [[Keys.LAlt, Keys.LShiftKey, Keys.D3]] = [Keys.PrintScreen],                  // Shift-Command-3: Full screen screenshot.
        [[Keys.LAlt, Keys.LShiftKey, Keys.D4]] = [Keys.LWin, Keys.LShiftKey, Keys.S], // Shift-Command-4: Crosshair area screenshot.

        // Unix shortcuts (Control shortcuts)
        [[Keys.LControlKey, Keys.A]] = [Keys.Home],   // Control-A: Move to the beginning of the line or paragraph.
        [[Keys.LControlKey, Keys.E]] = [Keys.End],    // Control-E: Move to the end of a line or paragraph.
        [[Keys.LControlKey, Keys.F]] = [Keys.Right],  // Control-F: Move one character forward.
        [[Keys.LControlKey, Keys.B]] = [Keys.Left],   // Control-B: Move one character backward.
        [[Keys.LControlKey, Keys.N]] = [Keys.Down],   // Control-N: Move down one line.
        [[Keys.LControlKey, Keys.P]] = [Keys.Up],     // Control-P: Move up one line.
        [[Keys.LControlKey, Keys.D]] = [Keys.Delete], // Control-D: Delete the character to the right of the insertion point.
        [[Keys.LControlKey, Keys.H]] = [Keys.Back],   // Control-H: Delete the character to the left of the insertion point.
        [[Keys.LControlKey, Keys.O]] = [Keys.Enter],  // Control-O: Insert a new line after the insertion point.

        // Cursor movement
        [[Keys.LControlKey, Keys.Left]] = [Keys.LWin, Keys.LControlKey, Keys.Left],   // Control-Left: Switch to the adjacent desktop space to the left
        [[Keys.LControlKey, Keys.Right]] = [Keys.LWin, Keys.LControlKey, Keys.Right], // Control-Right: Switch to the adjacent desktop space to the right

        // Cursor movement - Word/Paragraph navigation
        [[Keys.LWin, Keys.Left]] = [Keys.LControlKey, Keys.Left],   // Option–Left Arrow: Move the insertion point to the beginning of the previous word.
        [[Keys.LWin, Keys.Right]] = [Keys.LControlKey, Keys.Right], // Option–Right Arrow: Move the insertion point to the end of the next word.
        [[Keys.LWin, Keys.Up]] = [Keys.LControlKey, Keys.Up],       // Option-Up Arrow: Move to the beginning of the current paragraph.
        [[Keys.LWin, Keys.Down]] = [Keys.LControlKey, Keys.Down],   // Option-Down Arrow: Move to the end of the current paragraph.

        // Cursor movement selection - Word/Paragraph navigation
        [[Keys.LWin, Keys.LShiftKey, Keys.Left]] = [Keys.LControlKey, Keys.LShiftKey, Keys.Left],   // Option–Shift–Left Arrow: Extend text selection to the beginning of the current word.
        [[Keys.LWin, Keys.LShiftKey, Keys.Right]] = [Keys.LControlKey, Keys.LShiftKey, Keys.Right], // Option–Shift–Right Arrow: Extend text selection to the end of the current word.
        [[Keys.LWin, Keys.LShiftKey, Keys.Up]] = [Keys.LControlKey, Keys.LShiftKey, Keys.Up],       // Option–Shift–Up Arrow: Extend text selection to the beginning of the current paragraph.
        [[Keys.LWin, Keys.LShiftKey, Keys.Down]] = [Keys.LControlKey, Keys.LShiftKey, Keys.Down],   // Option–Shift–Down Arrow: Extend text selection to the end of the current paragraph.

        // Cursor movement - Line/Document navigation
        [[Keys.LAlt, Keys.Left]] = [Keys.Home],                  // Command–Left Arrow: Move the insertion point to the beginning of the current line.
        [[Keys.LAlt, Keys.Right]] = [Keys.End],                  // Command–Right Arrow: Move the insertion point to the end of the current line.
        [[Keys.LAlt, Keys.Up]] = [Keys.LControlKey, Keys.Home],  // Command–Up Arrow: Move the insertion point to the beginning of the document.
        [[Keys.LAlt, Keys.Down]] = [Keys.LControlKey, Keys.End], // Command–Down Arrow: Move the insertion point to the end of the document.

        // Cursor movement selection - Line/Document navigation
        [[Keys.LAlt, Keys.LShiftKey, Keys.Left]] = [Keys.LShiftKey, Keys.Home],                  // Shift–Command–Left Arrow: Select the text between the insertion point and the beginning of the current line.
        [[Keys.LAlt, Keys.LShiftKey, Keys.Right]] = [Keys.LShiftKey, Keys.End],                  // Shift–Command–Right Arrow: Select the text between the insertion point and the end of the current line.
        [[Keys.LAlt, Keys.LShiftKey, Keys.Up]] = [Keys.LControlKey, Keys.LShiftKey, Keys.Home],  // Shift–Command–Up Arrow: Select the text between the insertion point and the beginning of the document.
        [[Keys.LAlt, Keys.LShiftKey, Keys.Down]] = [Keys.LControlKey, Keys.LShiftKey, Keys.End], // Shift–Command–Down Arrow: Select the text between the insertion point and the end of the document.

        // Deleting
        [[Keys.RAlt, Keys.Back]] = [Keys.Delete],                     // Command-Delete (Backspace): Move the selected item to the Trash.
        [[Keys.LWin, Keys.Back]] = [Keys.LControlKey, Keys.Back],     // Option-Delete: Delete the word to the left of the insertion point.
        [[Keys.LAlt, Keys.Back]] = [Keys.LControlKey, Keys.Back],     // Option-Delete: Delete the word to the left of the insertion point.
        [[Keys.LWin, Keys.Delete]] = [Keys.LControlKey, Keys.Delete], // Option-Forward Delete: Delete the word to the right of the insertion point.

        // Power & Session Management
        [[Keys.LWin, Keys.LAlt, Keys.Escape]] = [Keys.LWin, Keys.L],  // Option-Command-Esc: Force Quit (Task Manager)
    };

    public static Dictionary<List<Keys>, string> ShortcutsTextMap = new()
    {
        // Mac special characters (Right Option)
        [[Keys.RControlKey, Keys.V]] = "√",
        [[Keys.RControlKey, Keys.G]] = "©",
        [[Keys.RControlKey, Keys.R]] = "®",
        [[Keys.RControlKey, Keys.T]] = "†",
        [[Keys.RControlKey, Keys.W]] = "∑",
        [[Keys.RControlKey, Keys.P]] = "π",
        [[Keys.RControlKey, Keys.D]] = "∂",
        [[Keys.RControlKey, Keys.F]] = "ƒ",
        [[Keys.RControlKey, Keys.M]] = "µ",
        [[Keys.RControlKey, Keys.B]] = "∫",
        [[Keys.RControlKey, Keys.Y]] = "¥",
        [[Keys.RControlKey, Keys.J]] = "∆",
        [[Keys.RControlKey, Keys.K]] = "˚",
        
        // Mac Numbers and Punctuation (Right Option)
        [[Keys.RControlKey, Keys.D8]] = "•",          // Bullet
        [[Keys.RControlKey, Keys.D2]] = "™",          // Trademark
        [[Keys.RControlKey, Keys.D5]] = "∞",          // Infinity
        [[Keys.RControlKey, Keys.OemMinus]] = "–",    // En dash
        [[Keys.RControlKey, Keys.Shift, Keys.OemMinus]] = "—", // Em dash
        [[Keys.RControlKey, Keys.Oemplus]] = "≠",     // Not equal
        [[Keys.RControlKey, Keys.OemSemicolon]] = "…" // Ellipsis
    };

    public static Dictionary<List<Keys>, string> ShortcutsUriMap = new()
    {
        // System Settings via Option+Media Keys
        [[Keys.LWin, Keys.VolumeUp]] = "ms-settings:sound",   // Option-Volume Up: Open Sound preferences
        [[Keys.LWin, Keys.VolumeDown]] = "ms-settings:sound", // Option-Volume Down: Open Sound preferences
        [[Keys.LWin, Keys.VolumeMute]] = "ms-settings:sound", // Option-Mute: Open Sound preferences

        // Finder (Explorer) shortcuts
        [[Keys.LAlt, Keys.LShiftKey, Keys.D]] = "shell:Desktop",             // Shift-Command-D: Desktop
        [[Keys.LAlt, Keys.LShiftKey, Keys.H]] = "shell:Profile",             // Shift-Command-H: Home
        [[Keys.LWin, Keys.LAlt, Keys.L]] = "shell:Downloads",                // Option-Command-L: Downloads
        [[Keys.LAlt, Keys.LShiftKey, Keys.O]] = "shell:Personal",            // Shift-Command-O: Documents
        [[Keys.LAlt, Keys.LShiftKey, Keys.F]] = "shell:Recent",              // Shift-Command-F: Recents
        [[Keys.LAlt, Keys.LShiftKey, Keys.C]] = "shell:MyComputerFolder",    // Shift-Command-C: Computer
        [[Keys.LAlt, Keys.LShiftKey, Keys.K]] = "shell:NetworkPlacesFolder", // Shift-Command-K: Network
        [[Keys.LAlt, Keys.LShiftKey, Keys.U]] = "shell:ControlPanelFolder"   // Shift-Command-U: Utilities
    };

    public static Dictionary<List<Keys>, RunProgramEntry> ShortcutsAppMap = new()
    {
        // Power & Session Management
        [[Keys.LWin, Keys.LAlt, Keys.Escape]] = new RunProgramEntry("taskmgr.exe"),        // Option-Command-Esc: Force Quit (Task Manager)
        
        // Empty Trash
        [[Keys.LAlt, Keys.LShiftKey, Keys.Delete]] = new RunProgramEntry("powershell.exe", "-WindowStyle Hidden -Command \"Clear-RecycleBin -Force\""), // Shift-Command-Delete
    };
}