var tooltip=function(){var d="tt";var p=3;var f=3;var o=300;var g=10;var e=20;var k=95;var i=0;var l,q,m,n,j;var a=document.all?true:false;return{show:function(c,b){if(l==null){l=document.createElement("div");l.setAttribute("id",d);q=document.createElement("div");q.setAttribute("id",d+"top");m=document.createElement("div");m.setAttribute("id",d+"cont");n=document.createElement("div");n.setAttribute("id",d+"bot");l.appendChild(q);l.appendChild(m);l.appendChild(n);document.body.appendChild(l);l.style.opacity=0;l.style.filter="alpha(opacity=0)";document.onmousemove=this.pos}l.style.display="block";m.innerHTML=c;l.style.width=b?b+"px":"auto";if(!b&&a){q.style.display="none";n.style.display="none";l.style.width=l.offsetWidth;q.style.display="block";n.style.display="block"}if(l.offsetWidth>o){l.style.width=o+"px"}j=parseInt(l.offsetHeight)+p;clearInterval(l.timer);l.timer=setInterval(function(){tooltip.fade(1)},e)},pos:function(h){var c=a?event.clientY+document.documentElement.scrollTop:h.pageY;var b=a?event.clientX+document.documentElement.scrollLeft:h.pageX;l.style.top=(c-j)+"px";l.style.left=(b+f)+"px"},fade:function(h){var b=i;if((b!=k&&h==1)||(b!=0&&h==-1)){var c=g;if(k-b<g&&h==1){c=k-b}else{if(i<g&&h==-1){c=b}}i=b+(c*h);l.style.opacity=i*0.01;l.style.filter="alpha(opacity="+i+")"}else{clearInterval(l.timer);if(h==-1){l.style.display="none"}}},hide:function(){clearInterval(l.timer);l.timer=setInterval(function(){tooltip.fade(-1)},e)},setMaxWidth:function(b){o=b}}}();function changeFormLanguage(b){try{$("[data-original-text][data-translated-text]").each(function(){if([$(this).attr("data-original-text"),$(this).attr("data-translated-text")].indexOf($(this).val())>-1){$(this).val("")}})}catch(a){}$("#language").val(b);$("#language-changed").val("yes");$("form").first().submit()};