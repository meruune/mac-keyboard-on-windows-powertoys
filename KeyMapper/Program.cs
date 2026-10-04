using Newtonsoft.Json;
using System.Windows.Forms;
using static KeyMapper.Keymap;

namespace KeyMapper;

internal class Program
{
    private static void Main()
    {
        File.WriteAllText(Path.Join(Environment.CurrentDirectory, "default.json"),
            JsonConvert.SerializeObject(new RemapSettings
            {
                remapKeys = new RemapCollection
                {
                    inProcess = KeysMap.Select(entry => new RemapEntry
                    {
                        originalKeys = $"{(int)entry.Key}",
                        newRemapKeys = $"{(int)entry.Value}"
                    }).ToList()
                },
                remapKeysToText = new RemapCollection
                {
                    inProcess = []
                },
                remapShortcuts = new RemapCollection
                {
                    global = ShortcutsMap.Select(entry => new RemapEntry
                    {
                        originalKeys = string.Join(';', entry.Key.Cast<int>()),
                        newRemapKeys = string.Join(';', entry.Value.Cast<int>()),
                        exactMatch = true
                    }).Concat(ShortcutsTextMap.Select(entry => new RemapEntry
                    {
                        originalKeys = string.Join(';', entry.Key.Cast<int>()),
                        exactMatch = true,
                        unicodeText = entry.Value
                    })).Concat(ShortcutsUriMap.Select(entry => new RemapEntry
                    {
                        originalKeys = string.Join(';', entry.Key.Cast<int>()),
                        exactMatch = true,
                        runProgramElevationLevel = 0,
                        operationType = 2,
                        openUri = entry.Value,
                        unicodeText = "*Unsupported*"
                    }).Concat(ShortcutsAppMap.Select(entry => entry.Value.GetEntry(entry.Key)
                    ))).ToList(),
                    appSpecific = []
                },
                remapShortcutsToText = new RemapCollection
                {
                    global = [],
                    appSpecific = []
                }
            }, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
    }
}

public class RemapSettings
{
    public RemapCollection remapKeys { get; set; } // { inProcess = [] };
    public RemapCollection remapKeysToText { get; set; } // { inProcess = [] };
    public RemapCollection remapShortcuts { get; set; } // { global = [], appSpecific = [] };
    public RemapCollection remapShortcutsToText { get; set; } // { global = [], appSpecific = [] };
}

public class RemapCollection
{
    public List<RemapEntry> inProcess { get; init; }
    public List<RemapEntry> global { get; init; }
    public List<RemapEntry> appSpecific { get; init; }
}

public class RemapEntry
{
    public string originalKeys { get; set; } // ctrl+a -> 162;65
    public bool? exactMatch { get; set; } // For shortcuts
    public string newRemapKeys { get; set; }
    public int? operationType { get; set; } // 1 - for chords/path, 2 - for URI
    public string unicodeText { get; set; }
    public int? runProgramElevationLevel { get; set; } // 0:normal, 1:admin, 2:different
    public string openUri { get; set; }
    public int? runProgramAlreadyRunningAction { get; set; } // 0:show, 1:new, 2:nothing, 3:close, 4:kill
    public int? runProgramStartWindowType { get; set; } // 0:normal, 1:hidden
    public string runProgramFilePath { get; set; }
    public string runProgramArgs { get; set; }
    public string runProgramStartInDir { get; set; }
}

internal class RunProgramEntry(string path, string args = "")
{
    public ElevationLevels ElevationLevel { get; set; } = ElevationLevels.Normal;
    public RunningActions RunningAction { get; set; } = RunningActions.New;
    public StartWindowTypes StartWindowType { get; set; } = StartWindowTypes.Normal;
    public string Path { get; set; } = path;
    public string Args { get; set; } = args;
    public string WorkDir { get; set; } = string.Empty;

    public enum ElevationLevels
    {
        Normal = 0,
        Admin = 1,
        DifferentUser = 2
    }

    public enum RunningActions
    {
        Show = 0,
        New = 1,
        Nothing = 2,
        Close = 3,
        Kill = 4
    }

    public enum StartWindowTypes
    {
        Normal = 0,
        Hidden = 1
    }

    public RemapEntry GetEntry(List<Keys> keys)
    {
        return new RemapEntry
        {
            originalKeys = string.Join(';', keys.Cast<int>()),
            exactMatch = true,
            runProgramElevationLevel = (int)ElevationLevel,
            operationType = 1,
            runProgramAlreadyRunningAction = (int)RunningAction,
            runProgramStartWindowType = (int)StartWindowType,
            runProgramFilePath = Path,
            runProgramArgs = Args,
            runProgramStartInDir = WorkDir,
            unicodeText = "*Unsupported*"
        };
    }
}