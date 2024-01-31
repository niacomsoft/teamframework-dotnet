# 宏参数配置默认格式 ▪ Macro Parameter

>   [!IMPORTANT]
>
>   基于宏参数配置的默认格式采用和 `MSBuild` 相似的格式配置。
>
>   宏参数配置仅支持字母 `a-z` `A-Z` 数字 `英文 - 和下划线`

```xml
<!-- 无范围的宏参数配置。 -->

<configuration>
	<appSettings>
    	<add key="TemporaryFolderPath" value="$(BaseDir)/temp" />
    </appSettings>
</configuration>

<!-- 有范围的宏参数配置。 -->

<configuration>
	<appSettings>
    	<add key="TemporaryFolderPath" value="$(BaseDir)/v$(env:AppVersion)/temp" />
    </appSettings>
</configuration>
```

