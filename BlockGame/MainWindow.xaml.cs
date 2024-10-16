﻿using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows;

namespace BlockGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!IsAdministrator())
            {
                RunAsAdmin();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Путь к файлу hosts
                string filePath = @"C:\Windows\system32\drivers\etc\hosts";

                // Удаление файла, если он существует
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Создание записи
                string content = @"
0.0.0.0 store.epicgames.com
0.0.0.0 www.store.epicgames.com
0.0.0.0 epicgames.com
0.0.0.0 www.epicgames.com
0.0.0.0 launcher-public-service-prod06.ol.epicgames.com
0.0.0.0 www.launcher-public-service-prod06.ol.epicgames.com
0.0.0.0 help.epicgames.com
0.0.0.0 support.epicgames.com

0.0.0.0 store.steampowered.com
0.0.0.0 www.store.steampowered.com
0.0.0.0 cdn.cloudflare.steamstatic.com
0.0.0.0 www.cdn.cloudflare.steamstatic.com
0.0.0.0 help.steampowered.com
0.0.0.0 www.help.steampowered.com
0.0.0.0 steamcommunity.com
0.0.0.0 www.steamcommunity.com
0.0.0.0 media.steampowered.com
0.0.0.0 www.media.steampowered.com
0.0.0.0 yandex.ru/games
0.0.0.0 www.yandex.ru/games
0.0.0.0 playhop.com
0.0.0.0 www.playhop.com
0.0.0.0 vseigru.net
0.0.0.0 www.vseigru.net
0.0.0.0 games.yandex.ru
0.0.0.0 www.games.yandex.ru
0.0.0.0 yandex.kz/games/
0.0.0.0 www.yandex.kz/games/
0.0.0.0 ru.malavida.com
0.0.0.0 www.ru.malavida.com
0.0.0.0 poki.com
0.0.0.0 www.poki.com
0.0.0.0 ag.ru
0.0.0.0 www.ag.ru
0.0.0.0 m.yandex.ru
0.0.0.0 www.m.yandex.ru
0.0.0.0 heroeswm.ru
0.0.0.0 www.heroeswm.ru
0.0.0.0 1001games.com
0.0.0.0 www.1001games.com
0.0.0.0 igru.net
0.0.0.0 www.igru.net
0.0.0.0 gamelayer.ru
0.0.0.0 www.gamelayer.ru
0.0.0.0 vk.com
0.0.0.0 www.vk.com
0.0.0.0 multoigri.ru
0.0.0.0 www.multoigri.ru
0.0.0.0 flashdozor.ru
0.0.0.0 www.flashdozor.ru
0.0.0.0 youloveit.ru
0.0.0.0 www.youloveit.ru
0.0.0.0 pacogames.com
0.0.0.0 www.pacogames.com
0.0.0.0 strelyaj.ru
0.0.0.0 www.strelyaj.ru
0.0.0.0 igrulez.net
0.0.0.0 www.igrulez.net
0.0.0.0 gamaverse.ru
0.0.0.0 www.gamaverse.ru
0.0.0.0 worldoftanks.eu
0.0.0.0 www.worldoftanks.eu
0.0.0.0 worldoftanks.com
0.0.0.0 www.worldoftanks.com
0.0.0.0 tanki.su
0.0.0.0 www.tanki.su
0.0.0.0 worldoftanks.ru
0.0.0.0 www.worldoftanks.ru
0.0.0.0 ru.tankionline.com
0.0.0.0 www.ru.tankionline.com
0.0.0.0 tankionline.com
0.0.0.0 www.tankionline.com
0.0.0.0 tlauncher.org
0.0.0.0 www.tlauncher.org
0.0.0.0 tlauncher.en.uptodown.com
0.0.0.0 www.tlauncher.en.uptodown.com
0.0.0.0 ru-m.org
0.0.0.0 www.ru-m.org
0.0.0.0 tmonitoring.com
0.0.0.0 www.tmonitoring.com
0.0.0.0 ok.ru
0.0.0.0 www.ok.ru
0.0.0.0 downloads.digitaltrends.com
0.0.0.0 www.downloads.digitaltrends.com
0.0.0.0 yandex.ru
0.0.0.0 www.yandex.ru
0.0.0.0 yandex.ua
0.0.0.0 www.yandex.ua
0.0.0.0 yandex.by
0.0.0.0 www.yandex.by
0.0.0.0 yandex.com.tr
0.0.0.0 www.yandex.com.tr
0.0.0.0 yandex.uz
0.0.0.0 www.yandex.uz
0.0.0.0 yandex.com
0.0.0.0 www.yandex.com
0.0.0.0 stoboi.ru
0.0.0.0 www.stoboi.ru
0.0.0.0 media.vkplay.ru
0.0.0.0 www.media.vkplay.ru
0.0.0.0 ru.y8.com
0.0.0.0 www.ru.y8.com
0.0.0.0 games.mail.ru
0.0.0.0 www.games.mail.ru
0.0.0.0 two-players.ru
0.0.0.0 www.two-players.ru
0.0.0.0 min2win.ru
0.0.0.0 www.min2win.ru
0.0.0.0 kanobu.ru
0.0.0.0 www.kanobu.ru
0.0.0.0 igrydlyadevochki.ru
0.0.0.0 www.igrydlyadevochki.ru
0.0.0.0 stoigr.org
0.0.0.0 www.stoigr.org
0.0.0.0 GamesGo.net
0.0.0.0 www.GamesGo.net
0.0.0.0 dtf.ru
0.0.0.0 www.dtf.ru
0.0.0.0 onlineigry.net
0.0.0.0 www.onlineigry.net
0.0.0.0 goha.ru
0.0.0.0 www.goha.ru
0.0.0.0 diep.io
0.0.0.0 www.diep.io
0.0.0.0 playem.io
0.0.0.0 www.playem.io
0.0.0.0 crazygames.com
0.0.0.0 www.crazygames.com
0.0.0.0 bluestacks.com
0.0.0.0 www.bluestacks.com
0.0.0.0 slither.io
0.0.0.0 www.slither.io
0.0.0.0 slither-io.app
0.0.0.0 www.slither-io.app
0.0.0.0 agar.io
0.0.0.0 www.agar.io
0.0.0.0 agario.fun
0.0.0.0 www.agario.fun
0.0.0.0 emupedia.net
0.0.0.0 www.emupedia.net
0.0.0.0 one.sigmally.com
0.0.0.0 www.one.sigmally.com
0.0.0.0 paper-io.com
0.0.0.0 www.paper-io.com
0.0.0.0 paper-2.io
0.0.0.0 www.paper-2.io
0.0.0.0 ollgames.com
0.0.0.0 www.ollgames.com
0.0.0.0 paperio.site
0.0.0.0 www.paperio.site
0.0.0.0 paper-3.io
0.0.0.0 www.paper-3.io
0.0.0.0 sz-games.github.io
0.0.0.0 www.sz-games.github.io
0.0.0.0 paperio4.com
0.0.0.0 www.paperio4.com
0.0.0.0 dragonhunter.4399sy.ru
0.0.0.0 www.dragonhunter.4399sy.ru
0.0.0.0 reborn.thepw.ru
0.0.0.0 www.reborn.thepw.ru
0.0.0.0 moreigr.org
0.0.0.0 www.moreigr.org
0.0.0.0 thelastgame.ru
0.0.0.0 www.thelastgame.ru
0.0.0.0 ru.uptodown.com
0.0.0.0 www.ru.uptodown.com
0.0.0.0 GoFrag.ru
0.0.0.0 www.GoFrag.ru
0.0.0.0 itorrents-igruha.net
0.0.0.0 www.itorrents-igruha.net
0.0.0.0 ruscryde.net
0.0.0.0 www.ruscryde.net
0.0.0.0 bestgames.to
0.0.0.0 www.bestgames.to
0.0.0.0 uwow.biz
0.0.0.0 www.uwow.biz
0.0.0.0 roblox-igray-besplatno.pw
0.0.0.0 www.roblox-igray-besplatno.pw
0.0.0.0 blox-game.ru
0.0.0.0 www.blox-game.ru
0.0.0.0 roblox.com
0.0.0.0 www.roblox.com
0.0.0.0 turbopages.org
0.0.0.0 www.turbopages.org
0.0.0.0 roblox.ru.malavida.com
0.0.0.0 www.roblox.ru.malavida.com
0.0.0.0 roblox.softonic.ru
0.0.0.0 www.roblox.softonic.ru
0.0.0.0 roblox.ru.net
0.0.0.0 www.roblox.ru.net
0.0.0.0 BroTorrent.net
0.0.0.0 www.BroTorrent.net
0.0.0.0 thehubgame.org
0.0.0.0 www.thehubgame.org
0.0.0.0 lagofast.com
0.0.0.0 www.lagofast.com
0.0.0.0 utorrentgames.best
0.0.0.0 www.utorrentgames.best
0.0.0.0 notorgames.net
0.0.0.0 www.notorgames.net
0.0.0.0 vsetop.org
0.0.0.0 www.vsetop.org
0.0.0.0 brotor.org
0.0.0.0 www.brotor.org
0.0.0.0 repack-byrutor.org
0.0.0.0 www.repack-byrutor.org
0.0.0.0 thelastupd.org
0.0.0.0 www.thelastupd.org
0.0.0.0 androeed.ru
0.0.0.0 www.androeed.ru
0.0.0.0 torrent-games.best
0.0.0.0 www.torrent-games.best
0.0.0.0 torrent-games.games
0.0.0.0 www.torrent-games.games
0.0.0.0 gog.com
0.0.0.0 www.gog.com
0.0.0.0 winstation.ru
0.0.0.0 www.winstation.ru
0.0.0.0 moreigr.games
0.0.0.0 www.moreigr.games
0.0.0.0 repack-igruha.net
0.0.0.0 www.repack-igruha.net
0.0.0.0 igromagnit.net
0.0.0.0 www.igromagnit.net
0.0.0.0 zaka-zaka.com
0.0.0.0 www.zaka-zaka.com
0.0.0.0 gabestore.ru
0.0.0.0 www.gabestore.ru
0.0.0.0 ggsel.net
0.0.0.0 www.ggsel.net
0.0.0.0 steampay.com
0.0.0.0 www.steampay.com
0.0.0.0 4ga.me
0.0.0.0 www.4ga.me
0.0.0.0 vkplay.ru
0.0.0.0 www.vkplay.ru
0.0.0.0 gamersbase.store
0.0.0.0 www.gamersbase.store
0.0.0.0 rg.ru
0.0.0.0 www.rg.ru
0.0.0.0 addictinggames.com
0.0.0.0 www.addictinggames.com
0.0.0.0 newgrounds.com
0.0.0.0 www.newgrounds.com
0.0.0.0 armorgames.com
0.0.0.0 www.armorgames.com
0.0.0.0 friv.com
0.0.0.0 www.friv.com
0.0.0.0 razlozhi.ru
0.0.0.0 www.razlozhi.ru
0.0.0.0 sdelayhod.ru
0.0.0.0 www.sdelayhod.ru
0.0.0.0 igroutka.ru
0.0.0.0 www.igroutka.ru
0.0.0.0 play.google.com
0.0.0.0 www.play.google.com
0.0.0.0 crazygames.ru
0.0.0.0 www.crazygames.ru
0.0.0.0 itorrents-igruha.org
0.0.0.0 www.itorrents-igruha.org
0.0.0.0 cubiq.ru
0.0.0.0 www.cubiq.ru
0.0.0.0 cq.ru
0.0.0.0 www.cq.ru
0.0.0.0 game01.ru
0.0.0.0 www.game01.ru
0.0.0.0 ru.battleship-game.org
0.0.0.0 www.ru.battleship-game.org
0.0.0.0 f-igri.ru
0.0.0.0 www.f-igri.ru
0.0.0.0 elgoog.im
0.0.0.0 www.elgoog.im
0.0.0.0 drawize.com
0.0.0.0 www.drawize.com
0.0.0.0 onlineigry.com
0.0.0.0 www.onlineigry.com
0.0.0.0 flashplayer.ru
0.0.0.0 www.flashplayer.ru
0.0.0.0 silvergames.com
0.0.0.0 www.silvergames.com
0.0.0.0 games-all.net
0.0.0.0 www.games-all.net
0.0.0.0 byxatab.com
0.0.0.0 www.byxatab.com
0.0.0.0 xatab-repack.rip
0.0.0.0 www.xatab-repack.rip
0.0.0.0 xatab-repack.do.am
0.0.0.0 www.xatab-repack.do.am
0.0.0.0 lastgame.pro
0.0.0.0 www.lastgame.pro
0.0.0.0 byxatab.org
0.0.0.0 www.byxatab.org
0.0.0.0 torrent-games.link
0.0.0.0 www.torrent-games.link
0.0.0.0 kuplinov-play.games
0.0.0.0 www.kuplinov-play.games
0.0.0.0 repack-games.ru
0.0.0.0 www.repack-games.ru
0.0.0.0 rgmechanics.info
0.0.0.0 www.rgmechanics.info
0.0.0.0 s5.torrent-repack.club
0.0.0.0 www.s5.torrent-repack.club
0.0.0.0 ru.mehanik.games
0.0.0.0 www.ru.mehanik.games
0.0.0.0 torrent-gamer.pro
0.0.0.0 www.torrent-gamer.pro
0.0.0.0 cybershoke.net
0.0.0.0 www.cybershoke.net
0.0.0.0 fanigry.com
0.0.0.0 www.fanigry.com
0.0.0.0 mini.vkplay.ru
0.0.0.0 www.mini.vkplay.ru
0.0.0.0 crazygames-poki.com
0.0.0.0 www.crazygames-poki.com
0.0.0.0 playminigames.ru
0.0.0.0 www.playminigames.ru
0.0.0.0 igroutka.su
0.0.0.0 www.igroutka.su
0.0.0.0 igruonline.net
0.0.0.0 www.igruonline.net
0.0.0.0 ugonki.ru
0.0.0.0 www.ugonki.ru
0.0.0.0 flashroom.ru
0.0.0.0 www.flashroom.ru
0.0.0.0 ru.gombis.com
0.0.0.0 www.ru.gombis.com
0.0.0.0 ollgames.ru
0.0.0.0 www.ollgames.ru
0.0.0.0 playmap.ru
0.0.0.0 www.playmap.ru
0.0.0.0 ru.sgames.org
0.0.0.0 www.ru.sgames.org
0.0.0.0 4gameground.ru
0.0.0.0 www.4gameground.ru
0.0.0.0 igry-zlo.ru
0.0.0.0 www.igry-zlo.ru
0.0.0.0 topmmogames.org
0.0.0.0 www.topmmogames.org
0.0.0.0 igraz.ru
0.0.0.0 www.igraz.ru
0.0.0.0 gamevils.ru
0.0.0.0 www.gamevils.ru
0.0.0.0 igrutut.ru
0.0.0.0 www.igrutut.ru
0.0.0.0 flash4play.com
0.0.0.0 www.flash4play.com
0.0.0.0 gamva.ru
0.0.0.0 www.gamva.ru
0.0.0.0 more-games.ru
0.0.0.0 www.more-games.ru
0.0.0.0 gamepixel.ru
0.0.0.0 www.gamepixel.ru
0.0.0.0 gonki-games.ru
0.0.0.0 www.gonki-games.ru
0.0.0.0 online-gonki.ru
0.0.0.0 www.online-gonki.ru
0.0.0.0 ser-game.ru
0.0.0.0 www.ser-game.ru
0.0.0.0 igry-multiki.ru
0.0.0.0 www.igry-multiki.ru
0.0.0.0 playgame24.com
0.0.0.0 www.playgame24.com
0.0.0.0 besplatniegonki.ru
0.0.0.0 www.besplatniegonki.ru
0.0.0.0 gonkigames.ru
0.0.0.0 www.gonkigames.ru
0.0.0.0 girsa.ru
0.0.0.0 www.girsa.ru
0.0.0.0 xgame.pro
0.0.0.0 www.xgame.pro
0.0.0.0 game-forboys.ru
0.0.0.0 www.game-forboys.ru
0.0.0.0 gsflash.ru
0.0.0.0 www.gsflash.ru
0.0.0.0 online-gamez.ru
0.0.0.0 www.online-gamez.ru
0.0.0.0 igratvonline.ru
0.0.0.0 www.igratvonline.ru
0.0.0.0 vipigry.ru
0.0.0.0 www.vipigry.ru
0.0.0.0 byruthub.org
0.0.0.0 www.byruthub.org
0.0.0.0 online-games-free.ru
0.0.0.0 www.online-games-free.ru
0.0.0.0 freegamesboom.com
0.0.0.0 www.freegamesboom.com
0.0.0.0 tonna-games.ru
0.0.0.0 www.tonna-games.ru
0.0.0.0 flashhome.ru
0.0.0.0 www.flashhome.ru
0.0.0.0 gameshape.ru
0.0.0.0 www.gameshape.ru
0.0.0.0 girlsgogames.ru
0.0.0.0 www.girlsgogames.ru
0.0.0.0 moigry.net
0.0.0.0 www.moigry.net
0.0.0.0 flashek.ru
0.0.0.0 www.flashek.ru
0.0.0.0 game.ru
0.0.0.0 www.game.ru
0.0.0.0 gamzee.ru
0.0.0.0 www.gamzee.ru
0.0.0.0 myrealgames.com
0.0.0.0 www.myrealgames.com
0.0.0.0 twoplayergames.org
0.0.0.0 www.twoplayergames.org
0.0.0.0 games-flash-online.com
0.0.0.0 www.games-flash-online.com
0.0.0.0 kolhosniki.ru
0.0.0.0 www.kolhosniki.ru
0.0.0.0 kongregate.com
0.0.0.0 crazygames.org
0.0.0.0 www.crazygames.org
0.0.0.0 miniclip.com
0.0.0.0 www.miniclip.com
0.0.0.0 frivclassic.info
0.0.0.0 www.frivclassic.info
0.0.0.0 www.kongregate.com
0.0.0.0 freeonlinegames.com
0.0.0.0 www.freeonlinegames.com
0.0.0.0 crazymonkeygames.com
0.0.0.0 www.crazymonkeygames.com
0.0.0.0 shockwave.com
0.0.0.0 www.shockwave.com
0.0.0.0 nitrome.com
0.0.0.0 www.nitrome.com
0.0.0.0 y8.com
0.0.0.0 www.y8.com
0.0.0.0 agame.com
0.0.0.0 www.agame.com
0.0.0.0 mousebreaker.com
0.0.0.0 www.mousebreaker.com
0.0.0.0 primarygames.com
0.0.0.0 www.primarygames.com
0.0.0.0 kizi.com
0.0.0.0 www.kizi.com
0.0.0.0 playhub.com
0.0.0.0 www.playhub.com
0.0.0.0 funnygames.org
0.0.0.0 www.funnygames.org
0.0.0.0 bgames.com
0.0.0.0 www.bgames.com
0.0.0.0 bubblebox.com
0.0.0.0 www.bubblebox.com
0.0.0.0 coolmathgames.com
0.0.0.0 www.coolmathgames.com
0.0.0.0 friv.cm
0.0.0.0 www.friv.cm
0.0.0.0 escapegames24.com
0.0.0.0 www.escapegames24.com
0.0.0.0 unblockedgames66ez.com
0.0.0.0 www.unblockedgames66ez.com
0.0.0.0 hudgames.com
0.0.0.0 www.hudgames.com
0.0.0.0 friv2020.com
0.0.0.0 www.friv2020.com
0.0.0.0 friv2019games.com
0.0.0.0 www.friv2019games.com
0.0.0.0 gamedesire.com
0.0.0.0 www.gamedesire.com
0.0.0.0 zapak.com
0.0.0.0 www.zapak.com
0.0.0.0 xbox.com
0.0.0.0 www.xbox.com
0.0.0.0 rockstargames.com
0.0.0.0 www.rockstargames.com
0.0.0.0 store.ubisoft.com
0.0.0.0 www.store.ubisoft.com
0.0.0.0 vgtimes.ru
0.0.0.0 www.vgtimes.ru
0.0.0.0 ubisoft.com
0.0.0.0 www.ubisoft.com
0.0.0.0 minecraft.net
0.0.0.0 www.minecraft.net
0.0.0.0 terraria.org
0.0.0.0 www.terraria.org
0.0.0.0 terraria.en.uptodown.com
0.0.0.0 www.terraria.en.uptodown.com
0.0.0.0 paradoxinteractive.com
0.0.0.0 www.paradoxinteractive.com
0.0.0.0 tyranny.obsidian.net
0.0.0.0 www.tyranny.obsidian.net
0.0.0.0 create.fortnite.com
0.0.0.0 www.create.fortnite.com
0.0.0.0 minecraft-inside.ru
0.0.0.0 www.minecraft-inside.ru
0.0.0.0 game-game.com.ua
0.0.0.0 www.game-game.com.ua
0.0.0.0 girlplays.ru
0.0.0.0 www.girlplays.ru
0.0.0.0 vseshariki.net
0.0.0.0 www.vseshariki.net
0.0.0.0 stopgame.ru
0.0.0.0 www.stopgame.ru
0.0.0.0 sharikionline.com
0.0.0.0 www.sharikionline.com
0.0.0.0 old-dos.ru
0.0.0.0 www.old-dos.ru
0.0.0.0 rvpkofficial.wixsite.com
0.0.0.0 www.rvpkofficial.wixsite.com
0.0.0.0 yandex.kz
0.0.0.0 www.yandex.kz
0.0.0.0 crazygames.com.ua
0.0.0.0 www.crazygames.com.ua
0.0.0.0 igru.com.ua
0.0.0.0 www.igru.com.ua
0.0.0.0 vseigru.fun
0.0.0.0 www.vseigru.fun
0.0.0.0 minigames.com
0.0.0.0 www.minigames.com
0.0.0.0 vseigru.su
0.0.0.0 www.vseigru.su
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.
0.0.0.0 
0.0.0.0 www.


";



                // Создание нового файла и запись в него
                File.WriteAllText(filePath, content + Environment.NewLine);

                // Очистка DNS-кэша
                FlushDNS();

                MessageBox.Show("Файл успешно обновлен и DNS-кэш очищен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FlushDNS()
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "ipconfig",
                    Arguments = "/flushdns",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(processInfo);
                process.WaitForExit();

                MessageBox.Show("DNS-кэш успешно очищен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при очистке DNS-кэша: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RunAsAdmin()
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Verb = "runas"
            };

            try
            {
                Process.Start(processInfo);
                Application.Current.Shutdown();
            }
            catch (Exception)
            {
                MessageBox.Show("Запуск от имени администратора был отменен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteHostsFile(object sender, RoutedEventArgs e)
        {
            string hostsPath = @"C:\Windows\system32\drivers\etc\hosts";

            if (!IsAdministrator())
            {
                // Перезапуск приложения с правами администратора
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = Process.GetCurrentProcess().MainModule.FileName,
                    Verb = "runas"
                };
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                Application.Current.Shutdown();
                return;
            }

            try
            {
                if (File.Exists(hostsPath))
                {
                    File.Delete(hostsPath);
                    MessageBox.Show("Файл hosts успешно удален.");
                }
                else
                {
                    MessageBox.Show("Файл hosts не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении файла: {ex.Message}");
            }
        }
    }
}
