using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Models;
using Network;
using SkillBridge.Message;
using UnityEngine;

public class MapService : Singleton<MapService>, IDisposable
{
    
    public int CurrentMapId { get; set; }
    
    public MapService()
    {
        MessageDistributer.Instance.Subscribe<MapCharacterEnterResponse>(this.OnCharacterEnterMap);
        MessageDistributer.Instance.Subscribe<MapCharacterLeaveResponse>(this.OnCharacterLeaveMap);
    }

    public void Dispose()
    {
        MessageDistributer.Instance.Unsubscribe<MapCharacterEnterResponse>(this.OnCharacterEnterMap);
        MessageDistributer.Instance.Unsubscribe<MapCharacterLeaveResponse>(this.OnCharacterLeaveMap);
    }
    
    void OnCharacterEnterMap(object sender, MapCharacterEnterResponse response)
    {
        Debug.LogFormat("OnCharacterEnterMap:{0} [{1}]", response.mapId, response.Characters.Count);

        foreach (var character in response.Characters)
        {
            if (character.Id == User.Instance.CurrentCharacter.Id)
            {
                User.Instance.CurrentCharacter = character;
            }
            CharacterManager.Instance.AddCharacter(character);
        }

        if (CurrentMapId != response.mapId)
        {
            CurrentMapId = response.mapId;

            EnterMap(CurrentMapId);
        }
    }

    private void EnterMap(int mapId)
    {
        if (DataManager.Instance.Maps.TryGetValue(mapId,out var map))
        {
            User.Instance.CurrentMapData = map;
            SceneManager.Instance.LoadScene(map.Resource);
        }
    }


    void OnCharacterLeaveMap(object sender, MapCharacterLeaveResponse response)
    {
        
    }

    public void Init()
    {
        
    }
}
