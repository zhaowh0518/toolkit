图片生成视频
ffmpeg -f image2 -i %03d.jpg -r 12 -s 1024*768  foo.avi
音频和视频的合成
ffmpeg -i 2.avi -i 3.mp3 -vcodec copy -acodec copy 0.avi 
音频截取
ffmpeg -ss 00:00:10 -t 00:01:22 -i 五月天-突然好想你.mp3  output.mp3


-r=1

frame=    6
fps=3.3 
q=1.6 
Lsize=296kB 
time=00:00:06.00 
bitrate= 403.6kbits
s dup=0 
drop=94
video:290kB 
audio:0kB 
subtitle:0 
global headers:0kB 
muxing overhead 1.988995%

-r=0.2

frame=    3 fps=1.7 q=2.0 Lsize=     101kB time=00:00:15.00 bitrate=  55.2kbi
s dup=0 drop=97
video:95kB audio:0kB subtitle:0 global headers:0kB muxing overhead 5.967354%

1280×720

4s/张 时长40s

number=8 times=1 s=24 length=00:00:03 size=617K imagenumber=10 1024*768

number=8 times=10 s=24 length=00:00:32 size=2.4M imagenumber=10 1024*768

number=8 times=10 s=24 length=00:00:32 size=5.06M imagenumber=10 1920*1080


为视频重新编码以适合在iPod/iPhone上播放
ffmpeg -i source_video.avi input -acodec aac -ab 128kb -vcodec mpeg4 -b 1200kb -mbd 2 -flags +4mv+trell -aic 2 -cmp 2 -subcmp 2 -s 320x180 -title X final_video.mp4

设置视频大小
ffmpeg -f image2 -framerate 1.0/3.0 -i E:\test\input\%d.jpg -r 12 -s 1024X768 -q:v 1 -y  E:\test\output\1.avi

VCD
ffmpeg -i E:\test\output\1.avi -target pal-vcd E:\test\output\1.mpg