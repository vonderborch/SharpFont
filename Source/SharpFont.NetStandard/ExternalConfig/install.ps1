param($installPath, $toolsPath, $package, $project)
 
# change deployed artifact to copy-to-bin
$project.ProjectItems.Item("lib").ProjectItems.Item("x64").ProjectItems.Item("freetype6.xml").Properties.Item("CopyToOutputDirectory").Value = 1
$project.ProjectItems.Item("lib").ProjectItems.Item("x86").ProjectItems.Item("freetype6.xml").Properties.Item("CopyToOutputDirectory").Value = 1
